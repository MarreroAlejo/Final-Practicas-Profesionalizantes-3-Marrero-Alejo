using SERVICES.Dao.Contracts;
using SERVICES.Domain.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Dao.Implementations.SqlServer.Mappers
{
    public sealed class PatenteMapper : IObjectMapper<Patente>
    {
        #region Singleton
        private readonly static PatenteMapper _instance = new PatenteMapper();

        public static PatenteMapper Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteMapper()
        {
            //Implement here the initialization code
        }
        #endregion    }


        public Patente Fill(object[] values)
        {
            //Hidratar el objeto patente
            Patente patente = new Patente();
            patente.Id = Guid.Parse(values[0].ToString());
            patente.Nombre = values[1].ToString();
            patente.DataKey = values[2].ToString();
            return patente;
        }

    }
}
