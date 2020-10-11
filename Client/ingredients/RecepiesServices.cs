using DAL.recepie;
using Domain.Recepies;

namespace Client.ingredients
{
    public class RecepiesServices
    {
        private RecepieRepository _repository = new RecepieRepository();
        
        public Recepie GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public void Create(Recepie recepie) {
            _repository.Create(recepie);
        }
        
        public void ChangeStatus(Recepie recepie, RecepieStatus recepieStatus)
        {
            recepie.Status = recepieStatus;
            _repository.Create(recepie);
        }
    }
}