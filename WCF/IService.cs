using Infrastructure;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<TelephoneNote> GetAll();

        [OperationContract]
        void Add(TelephoneNote telephoneNote);

        [OperationContract]
        void Update(TelephoneNote telephoneNote);

        [OperationContract]
        void Delete(TelephoneNote telephoneNote);
    }
}
