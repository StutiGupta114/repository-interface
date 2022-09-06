using RI.Model;
using RI.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //pass connection string using dependency injection
            var dbContext = new DbContext("{connectionString goes here}");
            var unitOfWork = new RI.UnitOfWork.UnitOfWork(dbContext);
          
            var sample = new SampleClass() { Id = 1, Text = "testing" };

            //controller methods
            unitOfWork.SampleRepository.Add(sample);
            unitOfWork.Save();

            unitOfWork.SampleRepository.Find(x => x.Id == 1);

            unitOfWork.SampleRepository.Get(sample.Id);

            unitOfWork.SampleRepository.GetAll();

            unitOfWork.SampleRepository.Remove(sample);

        }
    }
}
