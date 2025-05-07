using SERVICES.Dao.Contracts;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Implementations.SqlServer.Mappers
{
    public sealed class FamiliaMapper : IObjectMapper<Familia>
    {
        #region Singleton
        private readonly static FamiliaMapper _instance = new FamiliaMapper();

        public static FamiliaMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaMapper()
        {
            //Implement here the initialization code
        }
        #endregion

        public Familia Fill(object[] values)
        {
            //Nivel de hidratación 1 : Primitivos
            Familia familia = new Familia();
            familia.Id = Guid.Parse(values[0].ToString());
            familia.Nombre = values[1].ToString();

            ////Nivel de hidratación 2 : Agregaciones
            //FamiliaFamiliaRepository.Current.GetCount(familia);
            //FamiliaPatenteRepository.Current.GetCount(familia);
            return familia;
        }
    }
}
