using EstudiantePrestamoReportes.DAL;
using EstudiantePrestamoReportes.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstudiantePrestamoReportes.BLL
{
    public class PrestamosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(e => e.IdPrestamo == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        private static bool Insertar(Prestamos prestamos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Prestamos.Add(prestamos);
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        private static bool Modificar(Prestamos prestamos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(prestamos).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        public static bool Guardar(Prestamos prestamos)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Prestamos.Add(prestamos);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var prestamos = contexto.Prestamos.Find(id);

                if (prestamos != null)
                {
                    contexto.Prestamos.Remove(prestamos);
                    key = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = contexto.Prestamos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return prestamos;
        }
    }
}
