using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using RI.Model;
using RI.Repository;

namespace RITest.RepositoryTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Add_SampleClassObjectPassed_ProperMethodCalled()
        {
            var sampleClass = new SampleClass();

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<SampleClass>>();
            context.Setup(x => x.Set<SampleClass>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<SampleClass>())).Returns(sampleClass);
          
            var repository = new Repository<SampleClass>(context.Object);
            repository.Add(sampleClass);

            context.Verify(x => x.Set<SampleClass>());
            dbSetMock.Verify(x => x.Add(It.Is<SampleClass>(y => y == sampleClass)));
        }

        [TestMethod]
        public void Remove_SampleClassObjectPassed_ProperMethodCalled()
        {
            var sampleClass = new SampleClass();

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<SampleClass>>();
            context.Setup(x => x.Set<SampleClass>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<SampleClass>())).Returns(sampleClass);

            var repository = new Repository<SampleClass>(context.Object);
            repository.Remove(sampleClass);

            context.Verify(x => x.Set<SampleClass>());
            dbSetMock.Verify(x => x.Remove(It.Is<SampleClass>(y => y == sampleClass)));
        }

        [TestMethod]
        public void Get_SampleClassObjectPassed_ProperMethodCalled()
        {
            var sampleClass = new SampleClass();

            var context = new Mock<DbContext>();
            var dbSetMock = new Mock<DbSet<SampleClass>>();

            context.Setup(x => x.Set<SampleClass>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(sampleClass);

            var repository = new Repository<SampleClass>(context.Object);
            repository.Get(1);

            context.Verify(x => x.Set<SampleClass>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetAll_SampleClassObjectPassed_ProperMethodCalled()
        {
            var sampleClass = new SampleClass() { Id = 1 , Text = "testing"};
            var sampleClassList = new List<SampleClass>() { sampleClass };

            var dbSetMock = new Mock<DbSet<SampleClass>>();
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.Provider).Returns(sampleClassList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.Expression).Returns(sampleClassList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.ElementType).Returns(sampleClassList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.GetEnumerator()).Returns(sampleClassList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<SampleClass>()).Returns(dbSetMock.Object);

            var repository = new Repository<SampleClass>(context.Object);
            var result = repository.GetAll();

            //Assert.IsTrue(sampleClassList.SequenceEqual(result.ToList()));
            CollectionAssert.AreEqual(sampleClassList, result.ToList());
        }


        [TestMethod]

        public void Find_SampleClassObjectPassed_ProperMethodCalled()
        {
            var sampleClass = new SampleClass() { Id = 1 , Text = "testing" };
            var sampleClassList = new List<SampleClass>() { sampleClass };

            var dbSetMock = new Mock<DbSet<SampleClass>>();
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.Provider).Returns(sampleClassList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.Expression).Returns(sampleClassList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.ElementType).Returns(sampleClassList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<SampleClass>>().Setup(x => x.GetEnumerator()).Returns(sampleClassList.AsQueryable().GetEnumerator());

            var context = new Mock<DbContext>();
            context.Setup(x => x.Set<SampleClass>()).Returns(dbSetMock.Object);

            var repository = new Repository<SampleClass>(context.Object);

            var result = repository.Find(x => x.Id == 1);

            Assert.IsTrue(sampleClassList.SequenceEqual(result.ToList()));
            //CollectionAssert.AreEqual(sampleClassList, result.ToList());
        }

    }
}
