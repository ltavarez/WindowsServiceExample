using Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleService.Procedure
{    
    public class ExecuteProcedure
    {

        private InventarioContext context { get; set; }

        public ExecuteProcedure()
        {
            context = new InventarioContext();
        }

        public async Task<int> ExecuteExistenciaDeProductos(int cantidadAlerta)
        {
            try
            {
                SqlParameter ParametroDeAlerta = new SqlParameter("ParametroDeAlerta", cantidadAlerta);
                ParametroDeAlerta.SqlDbType = SqlDbType.Int;

                var result = await context.Database.ExecuteSqlCommandAsync($@"execute [dbo].[AlertaDeExistencia] 
                      @ParametroDeAlerta = @ParametroDeAlerta ",
                      ParametroDeAlerta
                    );

                return result;
            }catch(Exception e)
            {
                return -1;
            }
        }
    }
}
