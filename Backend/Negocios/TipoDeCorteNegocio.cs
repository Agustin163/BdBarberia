using System.Data;
using BdBarberia.Datos;
using BdBarberia.Entidades;

namespace BdBarberia.Negocio
{
    public class TipoDeCorteNegocio
    {
        TipoDeCorteDatos datos = new TipoDeCorteDatos();

        public DataTable Listar()
        {
            return datos.Listar();
        }

        public void Agregar(TipoDeCorte corte)
        {
            if (string.IsNullOrWhiteSpace(corte.Tipo))
                throw new Exception("El tipo de corte no puede estar vacío");

            if (corte.Precio <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            datos.Insertar(corte);
        }

        public void Modificar(TipoDeCorte corte)
        {
            if (corte.IdTipoDeCorte <= 0)
                throw new Exception("ID inválido");

            if (string.IsNullOrWhiteSpace(corte.Tipo))
                throw new Exception("El tipo de corte no puede estar vacío");

            if (corte.Precio <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            datos.Modificar(corte);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new Exception("ID inválido");

            datos.Eliminar(id);
        }
    }
}
