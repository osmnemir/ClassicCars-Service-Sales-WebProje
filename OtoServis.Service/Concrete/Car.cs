using OtoServis.Data;
using OtoServis.Data.Concrete;
using OtoServis.Service.Abstract;

namespace OtoServis.Service.Concrete
{
    public class Car : CarRepository,ICarService
    {
        public Car(DatabaseContext context) : base(context)
        {
        }
    }
}
