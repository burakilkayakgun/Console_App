using ConsoleApp1.Models;

namespace ConsoleApp1.Data
{
    public interface IRepository
    {
        OperationResult Insert(animal animals, string str);
        OperationResult Insert(info info, string str);
    //    OperationResult Delete<T>(T t);
        OperationResult Delete(animal animal, string str);
        OperationResult Delete(info info, string s);
        OperationResult Update(animal animal, string s1, int i);
        OperationResult Update(info info, string s1, int i);
    }
}
