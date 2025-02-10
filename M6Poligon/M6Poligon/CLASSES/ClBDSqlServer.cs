using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CLASSES
{

    public class ClBDSqlServer
    {
        public String cadenaConnexioServidor { get; set; }
        public String nomBD { get; set; }

        private SqlConnection connexio { get; set; }

        // constructor
        public ClBDSqlServer(String xconnexio)
        {
            cadenaConnexioServidor = xconnexio;
        }

        // destructor
        ~ClBDSqlServer()
        {
        }

        public Boolean Connectar()
        {
            Boolean xb = false;

            connexio = new SqlConnection(cadenaConnexioServidor);
            try
            {
                connexio.Open();
                if (connexio.State == ConnectionState.Open)
                {
                    xb = true;
                }
            }
            catch (Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "No s'ha Pogut Conectar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean HiHaConnexio()
        {
            return (connexio != null);
        }

        public Boolean Desconnectar()
        {
            Boolean xb = true;

            try
            {
                connexio = null;
                if (connexio == null)
                {
                    xb = true;
                }
            }
            catch (Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "No s'ha Pogut Desconectar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return (xb);
        }

        public Boolean ObrirBD(String xnomBD)
        {
            Boolean xb = true;

            try
            {
                if(connexio==null)
                {
                    Connectar();
                }
                nomBD = xnomBD;
                connexio.ChangeDatabase(nomBD);
            }
            catch(Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "No s'ha Pogut Obrir la BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean TancarBD()
        {
            Boolean xb = true;

            try
            {
                nomBD = null;
                connexio.Close();
            }
            catch (Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "No s'ha Pogut Tancar la BD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean EstaOberta()
        {
            return (connexio.State == ConnectionState.Open);
        }

        public void Consulta(String xsql, ref DataSet xdset)
        {

            try
            {
                if(EstaOberta())
                {
                    if(xsql.StartsWith("SELECT "))
                    {
                        SqlDataAdapter dbAdaptador = new SqlDataAdapter(xsql, connexio);
                        xdset.Clear();
                        dbAdaptador.Fill(xdset);
                    }
                    else
                    {
                        throw new Exception("La Instruccio SQL no Comença amb SELECT");
                    }
                }
                else
                {
                    throw new Exception("La Connexio no esta oberta");
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "No s'ha Pogut fer la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                    
            
        }

        public object ConsultaEscalar(String xsql)
        {
            object xresultat = null;

            try
            {
                if (EstaOberta())
                {
                    if (xsql.StartsWith("SELECT "))
                    {
                        SqlCommand cmd = new SqlCommand(xsql, connexio);
                        xresultat = cmd.ExecuteScalar();

                    }
                    else
                    {
                        throw new Exception("La Instruccio SQL no Comença amb SELECT");
                    }
                }
                else
                {
                    throw new Exception("La Connexio no esta oberta");
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "No s'ha Pogut fer la Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xresultat);
        }

        public Boolean InserirDades(String xsql)
        {
            Boolean xb = false;

            try
            {
                if (EstaOberta())
                {
                    if (xsql.StartsWith("INSERT INTO "))
                    {
                        xb=executarOrdre(xsql);
                    }
                    else
                    {
                        throw new Exception("La Instruccio SQL no Comença amb SELECT");
                    }
                }
                else
                {
                    throw new Exception("La Connexio no esta oberta");
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "No s'ha Pogut fer el INSERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean ModificarDades(String xsql)
        {
            Boolean xb = false;

            try
            {
                if (EstaOberta())
                {
                    if (xsql.StartsWith("UPDATE "))
                    {
                        xb = executarOrdre(xsql);
                    }
                    else
                    {
                        throw new Exception("La Instruccio SQL no Comença amb SELECT");
                    }
                }
                else
                {
                    throw new Exception("La Connexio no esta oberta");
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "No s'ha Pogut fer el INSERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean SuprimirDades(String xsql)
        {
            Boolean xb = false;

            try
            {
                if (EstaOberta())
                {
                    if (xsql.StartsWith("DELETE "))
                    {
                        xb = executarOrdre(xsql);
                    }
                    else
                    {
                        throw new Exception("La Instruccio SQL no Comença amb SELECT");
                    }
                }
                else
                {
                    throw new Exception("La Connexio no esta oberta");
                }
            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message, "No s'ha Pogut fer el INSERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

        public Boolean executarOrdre(String xsql)
        {
            Boolean xb = true;

            try
            {
                SqlCommand comando= new SqlCommand(xsql, connexio);
                comando.ExecuteNonQuery();

            }
            catch (Exception excp)
            {
                xb = false;
                MessageBox.Show(excp.Message, "No s'ha Pogut Executar la instruccio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return (xb);
        }

    }
}
