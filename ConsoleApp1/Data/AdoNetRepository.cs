using System;
using System.Data.SqlClient;
using ConsoleApp1.Models;

namespace ConsoleApp1.Data
{
    public class AdoNetRepository : IRepository
    {
        SqlConnection connection = new SqlConnection("Data Source=EXCALIBUR;Initial Catalog=test_db;Integrated Security=True");


        public OperationResult Delete(info i, string s)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                string sql_3 = "delete from " + s + " where full_name= '" + i.full_name + "'";
                SqlCommand command1 = new SqlCommand(sql_3, connection);
                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }

        public OperationResult Delete(animal a, string s)
        {

            OperationResult opResult = new OperationResult();
            try
            {
                string sql_3 = "delete from " + s + " where full_name= '" + a.full_name + "'";
                SqlCommand command1 = new SqlCommand(sql_3, connection);
                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }
        
        public OperationResult Insert(animal a, string str)
        {
            OperationResult opResult = new OperationResult();
            try
            {
                string sql_1 = "insert into " + str + "(full_name,age,owner_name,species) values('" + a.full_name + "', '" + a.age + "','" + a.owner_name + "','" + a.species + "')";
                SqlCommand command = new SqlCommand(sql_1, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;
        }

        public OperationResult Insert(info i, string str)
        {

            OperationResult opResult = new OperationResult();
            try
            {
                string sql_1 = "insert into " + str + "(full_name,adress,animal_name) values('" + i.full_name + "','" + i.adress + "','" + i.animal_name + "')";
                SqlCommand command = new SqlCommand(sql_1, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;


        }

        public OperationResult Update(animal a, string s, int id)
        {

            OperationResult opResult = new OperationResult();
            try
            {
                string sql_3 = "update " + s + " set full_name = '" + a.full_name + "', age= " + a.age + " ,owner_name = '" + a.owner_name + "', species ='" + a.species + "' where id= '" + id + "'";
                SqlCommand command1 = new SqlCommand(sql_3, connection);
                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;

        }

        public OperationResult Update(info i, string s, int id)
        {

            OperationResult opResult = new OperationResult();
            try
            {
                string sql_3 = "update " + s + " set full_name = '" + i.full_name + "', adress= '" + i.adress + "', animal_name ='" + i.animal_name + "' where id= '" + id + "'";
                SqlCommand command1 = new SqlCommand(sql_3, connection);
                connection.Open();
                command1.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                opResult.SetException(ex);
            }

            return opResult;

        }
    }
}
