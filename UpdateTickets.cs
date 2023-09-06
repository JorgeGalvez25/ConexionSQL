using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ConexionSQL
{
    [ComVisible(true), Guid("c7863b93-5f3a-4270-918b-5119105e0162"), ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class UpdateTickets
    {
        public UpdateTickets()
        {

        }

        [ComVisible(true)]
        public string ActualizarIdTicket(int ticketId, float importe, float litros, string cadenaCnx)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaCnx);

                connection.Open();

                string query = "UPDATE TRANSACCION SET VOLUMEN=@VOLUMEN, IMPORTE=@IMPORTE, TOTALIZADORFINAL=TOTALIZADORANTERIOR+@VOLUMEN WHERE IDTRANSACCION=@IDTRANSACCION";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VOLUMEN", litros);
                command.Parameters.AddWithValue("@IMPORTE", importe);
                command.Parameters.AddWithValue("@IDTRANSACCION", ticketId);
                int registros = command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();


                return registros.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [ComVisible(true)]
        public string ObtenerIdCorte(string fecha, string cadenaCnx)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaCnx);

                connection.Open();

                string query = "SELECT IdCorte FROM Corte WHERE CAST(FechaCorte AS date) = @FECHA";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FECHA", fecha);
                int corte = (Int32)command.ExecuteScalar();

                command.Dispose();
                connection.Close();


                return corte.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [ComVisible(true)]
        public string ActualizarCorteManguera(int corte, int manguera, float volumen, string cadenaCnx)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaCnx);

                connection.Open();

                string query = "UPDATE DETALLECORTEMANGUERA SET VOLUMENTRANSACCIONES=@VOLUMENTRANSACCIONES WHERE IDCORTE=@IDCORTE AND IDMANGUERA=@IDMANGUERA";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VOLUMENTRANSACCIONES", volumen);
                command.Parameters.AddWithValue("@IDCORTE", corte);
                command.Parameters.AddWithValue("@IDMANGUERA", manguera);
                int registros = command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return registros.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [ComVisible(true)]
        public string ActualizarCorteProducto(int corte, int producto, float volumen, float importe, string cadenaCnx)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaCnx);

                connection.Open();

                string query = "UPDATE DETALLECORTEPRODUCTO SET VolumenTransferidoTotalizador=@VolumenTransferidoTotalizador," +
                    "ImporteTransferidoTotalizador=@ImporteTransferidoTotalizador," +
                    "VolumenTransferidoTransacciones=@VolumenTransferidoTransacciones," +
                    "ImporteTransferidoTransacciones=@ImporteTransferidoTransacciones," +
                    "VolumenFinal=@VolumenFinal" +
                    " WHERE IDCORTE=@IDCORTE AND IDPRODUCTO=@IDPRODUCTO";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VolumenTransferidoTotalizador", volumen);
                command.Parameters.AddWithValue("@ImporteTransferidoTotalizador", importe);
                command.Parameters.AddWithValue("@VolumenTransferidoTransacciones", volumen);
                command.Parameters.AddWithValue("@ImporteTransferidoTransacciones", importe);
                command.Parameters.AddWithValue("@VolumenFinal", volumen);
                command.Parameters.AddWithValue("@IDCORTE", corte);
                command.Parameters.AddWithValue("@IDPRODUCTO", producto);
                int registros = command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return registros.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        [ComVisible(true)]
        public string ActualizarCorte(int corte, float volumen, float importe, string cadenaCnx)
        {
            try
            {
                SqlConnection connection = new SqlConnection(cadenaCnx);

                connection.Open();

                string query = "UPDATE CORTE SET VolumenTransferidoTotalizador=@VolumenTransferidoTotalizador," +
                    "ImporteTransferidoTotalizador=@ImporteTransferidoTotalizador," +
                    "VolumenTransferidoTransacciones=@VolumenTransferidoTransacciones," +
                    "ImporteTransferidoTransacciones=@ImporteTransferidoTransacciones" +
                    " WHERE IDCORTE=@IDCORTE";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VolumenTransferidoTotalizador", volumen);
                command.Parameters.AddWithValue("@ImporteTransferidoTotalizador", importe);
                command.Parameters.AddWithValue("@VolumenTransferidoTransacciones", volumen);
                command.Parameters.AddWithValue("@ImporteTransferidoTransacciones", importe);
                command.Parameters.AddWithValue("@IDCORTE", corte);
                int registros = command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                return registros.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}