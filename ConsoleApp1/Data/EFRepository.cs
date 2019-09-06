using ConsoleApp1.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ConsoleApp1.Data
{
    public class EFRepository : IRepository
    {
        DBContextEF DBContext = new DBContextEF("Data Source=EXCALIBUR;Initial Catalog=test_db;Integrated Security=True");

     /*
        OperationResult IRepository.Delete<T>(T t)
        {
            throw new NotImplementedException();
        }
     */

        OperationResult IRepository.Delete(animal animal, string str)
        {
            OperationResult opResult = new OperationResult();

            if (animal != null && string.IsNullOrEmpty(animal.full_name))
                return null;

            animal existAnimal = DBContext.Animals.FirstOrDefault(c => c.full_name == animal.full_name);
            if (existAnimal == null)
                return null;
            try
            {
                DBContext.Animals.Remove(existAnimal);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }


        OperationResult IRepository.Delete(info info, string s)
        {
            OperationResult opResult = new OperationResult();

            if (info != null && string.IsNullOrEmpty(info.full_name))
                return null;

            info existInfo = DBContext.Informations.FirstOrDefault(c => c.full_name == info.full_name);
            if (existInfo == null)
                return null;

            try
            {
                DBContext.Informations.Remove(existInfo);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }
        

        OperationResult IRepository.Insert(animal animals, string str)
        {
            OperationResult opResult = new OperationResult();

            try
            {
                DBContext.Animals.Add(animals);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }

        OperationResult IRepository.Insert(info info, string str)
        {

            OperationResult opResult = new OperationResult();

            try
            {
                DBContext.Informations.Add(info);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }

        OperationResult IRepository.Update(animal animal, string s1, int id)
        {
            OperationResult opResult = new OperationResult();

            if (animal != null && string.IsNullOrEmpty(animal.full_name))
                return null;

            animal existAnimal = DBContext.Animals.FirstOrDefault(c => c.id == animal.id);
            if (existAnimal == null)
                return null;

            try
            {
                
                DBContext.Animals.AddOrUpdate(animal);
                DBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
            
        }

        OperationResult IRepository.Update(info info, string s1, int id)
        {
            OperationResult opResult = new OperationResult();

            if (info != null && string.IsNullOrEmpty(info.full_name))
                return null;

            info existInfo = DBContext.Informations.FirstOrDefault(c => c.id == info.id);
            if (existInfo == null)
                return null;

            try
            {
                DBContext.Informations.AddOrUpdate(info);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }
    } 
}
