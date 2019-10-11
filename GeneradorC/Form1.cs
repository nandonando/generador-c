using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneradorC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection _cnn;
        private DataTable dttTabla;
        string NombreColumnaID = "";
        //---ERIVERA---   String tipo columna funsiona para mandar a llamar la palabra reservada  IdDataTypeName ,GAF(Date)
        string TIPOColumnaID = "";
        string TIPOID = "";
        string FECHADELDIA = DateTime.Now.ToShortDateString();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbServidores.Items.Add(".\\SQLEXPRESS");
            //cmbServidores.Items.Add("192.168.168.33");
            //cmbServidores.Items.Add("192.168.168.37,2433");
            cmbServidores.Items.Add("<Buscar mas ...>");

            //---ERIVERA--- Configuracion para guardad las rutas  de entradas y salidas
      
            txtDirectorioEntrada.Text = GeneradorC.Properties.Settings.Default.DirectorioEntrada;
            txtDirectorioSalida.Text = GeneradorC.Properties.Settings.Default.DirectorioSalida;
            txtUsuario.Text = GeneradorC.Properties.Settings.Default.Usuario;


            //---ERIVERA--- Configuracion para guardad  las rutas de entrada y salida para un archivo XML.
            //XmlReader r = XmlReader.Create("Informacion_Generador.xml");
            //r.ReadStartElement("MiInfo");
            //txtDirectorioEntrada.Text = r.ReadElementContentAsString();
            //txtDirectorioSalida.Text = r.ReadElementContentAsString();
            //txtUsuario.Text = r.ReadElementContentAsString();
            //r.Close();
        }

        private void cmbServidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbServidores.Text == "<Buscar mas ...>")
            {
                SqlDataSourceEnumerator Servidores = SqlDataSourceEnumerator.Instance;

                DataTable dttServidores = Servidores.GetDataSources();
                
                //--FFLORES--- Mediante la función GetDataSources, obtengo una tabla con la información de los servidores

                foreach (DataRow row in dttServidores.Rows)
                {
                    cmbServidores.Items.Add(row["ServerName"].ToString() + "\\" + row["InstanceName"].ToString());
                }

            }

        }

        private void AbrirConexion()
        {
            try
            {
                _cnn = new SqlConnection();
                //---FFLORES--- 'Asignar la Cadena de conexión para la base SQL Server. 
                if (chkSeguridadIntegrada.Checked)
                {
                    _cnn.ConnectionString = "Data Source=" + cmbServidores.Text + ";Initial Catalog=" + cmbBasesDeDatos.SelectedItem + ";Integrated Security=True";
                }
                else
                {
                    _cnn.ConnectionString = "Data Source=" + cmbServidores.Text + ";Initial Catalog=" + cmbBasesDeDatos.SelectedItem + ";User Id=" + txtUsuario.Text + ";Password=" + txtPwd.Text;
                }
                //---FFLORES---  abrir la conexión   
                _cnn.Open();
            }
            catch (Exception errorEncontrado)
            {
                MessageBox.Show(errorEncontrado.Message);
            }
        }

        private void CerrarConexion()
        {
            try
            {
                _cnn.Close();
                _cnn.Dispose();
                _cnn = null;
            }
            catch (Exception)
            {

            }
        }

        private void cmbServidores_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbServidores.Text == "")
                    return;

                using (SqlConnection conexion = new SqlConnection())
                {
                    //---FFLORES---- 'Asignar la Cadena de conexión para la base SQL Server. 
                    if (chkSeguridadIntegrada.Checked)
                    {
                        conexion.ConnectionString = "Data Source=" + cmbServidores.Text + ";Integrated Security=True";
                    }
                    else
                    {
                        conexion.ConnectionString = "Data Source=" + cmbServidores.Text + ";User Id=" + txtUsuario.Text + ";Password=" + txtPwd.Text;
                    }
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "exec master.dbo.sp_databases";
                        cmd.Connection = conexion;

                        SqlDataAdapter Adaptador = new SqlDataAdapter(cmd);
                        using (DataTable dttBD = new DataTable())
                        {
                            Adaptador.Fill(dttBD);
                            foreach (DataRow fila in dttBD.Rows)
                            {
                                cmbBasesDeDatos.Items.Add(fila["DataBase_Name"]);

                            }

                        }
                    }
                }
            }
            catch (Exception errorEncontrado)
            {
                MessageBox.Show(errorEncontrado.Message);
            }

        }

        private void cmbBasesDeDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AbrirConexion();
                //---FFLORES--- Vaciamos el combo de tablas
                cmbTablas.Items.Clear();
                cmbTablas.Text = "";
                txtEsquema.Text = "";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "exec " + cmbBasesDeDatos.SelectedItem + ".dbo.sp_tables";
                    cmd.Connection = _cnn;

                    SqlDataAdapter Adaptador = new SqlDataAdapter(cmd);
                    using (DataTable dttBD = new DataTable())
                    {
                        Adaptador.Fill(dttBD);
                        foreach (DataRow fila in dttBD.Rows)
                        {
                            cmbTablas.Items.Add((string)fila["TABLE_OWNER"] + "." + (string)fila["TABLE_NAME"]);
                        }
                    }
                }

                CerrarConexion();
            }
            catch (Exception errorEncontrado)
            {
                MessageBox.Show(errorEncontrado.Message);
            }
        }

        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
          try
            {
                AbrirConexion();

                using (SqlCommand cmd = new SqlCommand())
                {
                    dttTabla = new DataTable();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT Top 1 * FROM " + cmbTablas.Text;
                    cmd.Connection = _cnn;

                    SqlDataReader Lector = cmd.ExecuteReader();
                    dttTabla = Lector.GetSchemaTable();
                    dttTabla.Columns.Add("Seleccion", typeof(bool));
                    dttTabla.Columns.Add("Notas", typeof(string));
                    dgvColumnas.DataSource = dttTabla;

                    dgvColumnas.Columns["Seleccion"].DisplayIndex = 0;

                    txtTabla.Text = cmbTablas.Text.Substring(cmbTablas.Text.IndexOf(".") + 1, cmbTablas.Text.Length - (cmbTablas.Text.IndexOf(".") + 1));
                    txtEsquema.Text = cmbTablas.Text.Substring(0, cmbTablas.Text.IndexOf("."));
                }
                CerrarConexion();
            }
            catch (Exception errorEncontrado)
            {
                MessageBox.Show(errorEncontrado.Message);
            }
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
           try
            {
                DirectoryInfo di = new DirectoryInfo(txtDirectorioEntrada.Text);
                //---ERIVERA---- Crear la carpeta del directorio de salida
                string path = txtDirectorioSalida.Text;

                path = (path +@"\" + txtTabla.Text);

                Directory.CreateDirectory(path);
                bool isForEach = false;

                StreamReader fichero = null;


                //---FFLORES--- Leemos todos los archivos del directorio de entrada
                foreach (var fi in di.GetFiles())
                {
                    fichero = File.OpenText(fi.FullName);

                    ArrayList arrFichero = new ArrayList();
                    ArrayList arrCiclo = new ArrayList();

                    string lineaRenglon = "";
                    //---FFLORES--- Aquí vemos en que numero de fila vamos
                    int NumeroFila = 0;


                    bool UltimaFila = false;

                    /*---FFLORES--- Aquí buscamos el nombre del archivo y la extensión*/
                    string NombreArchivoSalida = "";
                    string ExtensionArchivoSalida = "";
                    string strLinea = "";
                    while ((strLinea = fichero.ReadLine()) != null)
                    {
                        arrFichero.Add(strLinea);
                    }
                    fichero.Close();
                 

                    NombreArchivoSalida = ReemplazarPalabrasReservadas((string)arrFichero[1]);

                    ExtensionArchivoSalida = ReemplazarPalabrasReservadas((string)arrFichero[2]);

                    /*---FFLORES--- Aqui recorremos la tabla para saber el ID de la tabla*/
                    /*---FFLORES---  En el mismo ciclo se agrega el switch para que tome la palabra reservada*/
                    foreach (DataRow fila in dttTabla.Rows)
                    {
                        if ((bool)fila["IsIdentity"])
                        {
                            NombreColumnaID = fila["ColumnName"].ToString();
                            TIPOColumnaID = fila["DataTypeName"].ToString();
                            switch (fila["DataTypeName"].ToString())
                            {
                                case "decimal":
                                    TIPOColumnaID = fila["DataTypeName"].ToString() + "(" + fila["NumericPrecision"].ToString() + "," + fila["NumericScale"].ToString() + ")";

                                    break;
                            }
                        }
                    }
             
                    //---ERIVERA--- Le agregamos en la linea 294  "//" para que  guarde los documentos de salida en una carpeta
                   using (StreamWriter ficheroSalida = new StreamWriter(txtDirectorioSalida.Text + "\\" + txtTabla.Text + "\\" + NombreArchivoSalida.Replace("##", "") + "." + ExtensionArchivoSalida.Replace("##", "")))
                   
                    {
                        foreach (string linea in arrFichero)
                        {

                            lineaRenglon = linea;

                            if (lineaRenglon.Contains("GAFForEach") == true)
                                if (!lineaRenglon.Contains("GAFForSinIdEach") == true)
                                {

                                    lineaRenglon = "GAFForEach";

                                }

                            if (lineaRenglon.Contains("GAFEndForEach") == true)
                                if (!lineaRenglon.Contains("GAFEndForSinIdEach") == true)
                                {

                                    lineaRenglon = "GAFEndForEach";


                                }
                            //---ERIVERA---  Se agrega la palabra  reservada  GAFForSinIdEach Y GAFEndForSinIdEach

                            if (lineaRenglon.Contains("GAFForSinIdEach") == true)

                            {


                                lineaRenglon = "GAFForSinIdEach";


                            }

                            if (lineaRenglon.Contains("GAFEndForSinIdEach") == true)


                            {
                                lineaRenglon = "GAFEndForSinIdEach";

                            }

                            if (lineaRenglon.Contains("GAFIF") == true)
                            {
                                lineaRenglon = "GAFIF";
                            }


                            switch (lineaRenglon)
                            {
                                case "GAFForEach":
                                    isForEach = true;

                                    break;
                                case "GAFEndForEach":
                                    NumeroFila = 0;
                                    foreach (DataRow fila in dttTabla.Rows)

                                    {

                                        NumeroFila += 1;
                                        string PalabraReservadaActual = "";
                                        foreach (string lista in arrCiclo)
                                        {

                                            if (NumeroFila == dttTabla.Rows.Count)
                                            {
                                                UltimaFila = true;
                                            }
                                            //---FFLORES--- Si encontramos una palabra reservada, la agregamos a la variable PalabraReservadaActual
                                            if (RegresaPalabraReservada(lista) != "")
                                                PalabraReservadaActual = RegresaPalabraReservada(lista);
                                            //---FFLORES---Aqui validamos el tipo de dato para insertar un valor u otro valor(Int32 o string etc)
                                            if (RegresaPalabraReservada(lista) == "")
                                            {
                                                switch (PalabraReservadaActual)
                                                {
                                                    case "GAFIfInt32":
                                                        if (fila["DataType"].ToString() == "System.Int32")
                                                        {

                                                            ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                      
                                                        }
                                                        break;
                                                    case "GAFIfBoolean":
                                                        if (fila["DataType"].ToString() == "System.Boolean")
                                                        {

                                                            ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                        }
                                                        break;
                                                    case "GAFIfString":
                                                        if (fila["DataType"].ToString() == "System.String")
                                                        {

                                                            ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                        }
                                                        break;
                                                    case "GAFIfDateTime":
                                                        if (fila["DataType"].ToString() == "System.DateTime")
                                                        {

                                                            ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));
                                                        }
                                                        break;
                                                    default:

                                                        ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                        break;

                                                }
                                            }

                                        }
                                        UltimaFila = false;
                                    }

                                    arrCiclo = new ArrayList();
                                    isForEach = false;
                                    break;
                                //---ERIVERA---  Se agrega en el case para para la palabra reservada  

                                case "GAFForSinIdEach":
                                    isForEach = true;

                                    break;
                                case "GAFEndForSinIdEach":
                                    NumeroFila = 1;

                                    foreach (DataRow fila in dttTabla.Rows)
                                        //---ERIVERA-----  Se agrega  la siguiente linea para quitar solamente el id
                                        if (!(bool)fila["IsIdentity"])
                                        {

                                            NumeroFila += 1;

                                            string PalabraReservadaActual = "";
                                            foreach (string lista in arrCiclo)
                                            {
                                                if (NumeroFila == dttTabla.Rows.Count)
                                                {

                                                    UltimaFila = true;

                                                }
                                                //---FFLORES----Si encontramos una palabra reservada, la agregamos a la variable PalabraReservadaActual
                                                if (RegresaPalabraReservada(lista) != "")
                                                    PalabraReservadaActual = RegresaPalabraReservada(lista);

                                                //---FFLORES---- Aqui validamos el tipo de dato para insertar un valor u otro valor(Int32 o string etc)
                                                if (RegresaPalabraReservada(lista) == "")
                                                {

                                                    switch (PalabraReservadaActual)
                                                    {
                                                        case "GAFIfInt32":
                                                            if (fila["DataType"].ToString() == "System.Int32")
                                                            {
                                                                ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                            }
                                                            break;
                                                        case "GAFIfBoolean":
                                                            if (fila["DataType"].ToString() == "System.Boolean")
                                                            {
                                                                ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                            }
                                                            break;
                                                        case "GAFIfString":
                                                            if (fila["DataType"].ToString() == "System.String")
                                                            {
                                                                ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                            }
                                                            break;
                                                        case "GAFIfDateTime":
                                                            if (fila["DataType"].ToString() == "System.DateTime")
                                                            {
                                                                ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                            }
                                                            break;
                                                        default:
                                                            ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lista, fila, UltimaFila));

                                                            break;

                                                    }

                                                }

                                            }

                                            UltimaFila = false;
                                        }

                                    arrCiclo = new ArrayList();
                                    isForEach = false;
                                    break;

                                case "GAFIF":
                                    isForEach = true;

                                    break;

                                default:

                                    if (isForEach == false && !lineaRenglon.Contains("GAFForSinIdEach") && !lineaRenglon.Contains("GAFEndForSinIdEach") && lineaRenglon.Contains("##") == false)

                                      ficheroSalida.WriteLine(ReemplazarPalabrasReservadas(lineaRenglon));

                                    break;
                            }

                            if (isForEach == true && lineaRenglon != "GAFForSinIdEach" && lineaRenglon != "GAFForEach")

                            {
                                arrCiclo.Add(lineaRenglon);
                            }
                        }
                    }

                }

                MessageBox.Show("Generado con exito");

            }

            catch (Exception errorEncontrado)
            {
                MessageBox.Show(errorEncontrado.Message);
            }

            //---ERIVERA--- Guarda los componentes de la configuracion de entrada y salida
            GeneradorC.Properties.Settings.Default.DirectorioEntrada = txtDirectorioEntrada.Text;
            GeneradorC.Properties.Settings.Default.DirectorioSalida = txtDirectorioSalida.Text;
            GeneradorC.Properties.Settings.Default.Usuario = txtUsuario.Text;
            GeneradorC.Properties.Settings.Default.Save();

            //---ERIVERA--- Directorios de entra y salida XML
            //XmlWriter w = XmlWriter.Create("Informacion_Generador.xml");
            //w.WriteStartElement("MiInfo");
            //w.WriteElementString("Directoriodeentrada", txtDirectorioEntrada.Text);
            //w.WriteElementString("Directoriodesalida", txtDirectorioSalida.Text);
            //w.WriteElementString("Usuario", txtUsuario.Text);
            //w.WriteEndElement();
            //w.Close();
        }

        private string ReemplazarPalabrasReservadas(string renglon)
        {
            renglon = renglon.Replace("GAF(NombreTabla)", txtTabla.Text);
            renglon = renglon.Replace("GAF(NombreEsquema)", txtEsquema.Text);
            renglon = renglon.Replace("GAF(ID)", NombreColumnaID);
            renglon = renglon.Replace("GAF(IdDataTypeName)", TIPOColumnaID);
            renglon = renglon.Replace("GAF(IdDataTypeName)", TIPOID);
            renglon = renglon.Replace("GAF(valor1)", txtValor1.Text);
            renglon = renglon.Replace("GAF(Date)", FECHADELDIA);
            renglon = renglon.Replace("GAF(valor2)", txtValor2.Text);

            return renglon;
        }

        private string ReemplazarPalabrasReservadas(string renglon, DataRow fila, bool UltimaFila)
        {

            renglon = renglon.Replace("GAF(NombreTabla)", txtTabla.Text);
            renglon = renglon.Replace("GAF(NombreEsquema)", txtEsquema.Text);
            renglon = renglon.Replace("GAF(ID)", NombreColumnaID);
            renglon = renglon.Replace("GAF(IdDataTypeName)", TIPOColumnaID);
            renglon = renglon.Replace("GAF(IdDataTypeName)", TIPOID);
            renglon = renglon.Replace("GAF(valor1)", txtValor1.Text);
            renglon = renglon.Replace("GAF(Date)", FECHADELDIA);
            renglon = renglon.Replace("GAF(valor2)", txtValor2.Text);

            if (UltimaFila)
            {
                renglon = renglon.Replace("GAF(,)", "");


            }

            renglon = renglon.Replace("GAF(,)", ",");



            if (UltimaFila)
            {

                renglon = renglon.Replace("GAF(Date)", FECHADELDIA);
            }

            renglon = renglon.Replace("GAF(ColumnName)", fila["ColumnName"].ToString());
            //---FFLORES--- Creamos la regla de camelCase
            string camelCase = fila["ColumnName"].ToString();
            string camelCaseTemp = camelCase.ToLower();

            camelCase = camelCase.Replace(camelCase[0], camelCaseTemp[0]);
            renglon = renglon.Replace("GAFcC(ColumnName)", camelCase);
            renglon = renglon.Replace("GAF(ColumnSize)", fila["ColumnSize"].ToString());
            renglon = renglon.Replace("GAF(DataType)", fila["DataType"].ToString().Replace("System.", ""));
            renglon = renglon.Replace("GAF(DataType)", fila["DataType"].ToString().Replace("[]", "()"));
     
            if (renglon.Contains("GAF(DataTypeName)"))

            {
               switch (fila["DataTypeName"].ToString())
                {
                    case "int":
                    case "datetime":
                    case "date":
                    case "money":
                    case "bit":
                    case "image":


                        renglon = renglon.Replace("GAF(DataTypeName)", fila["DataTypeName"].ToString());
                        break;
                    case "decimal":
                        renglon = renglon.Replace("GAF(DataTypeName)", fila["DataTypeName"].ToString() + "(" + fila["NumericPrecision"].ToString() + "," + fila["NumericScale"].ToString() + ")");

                        break;
                    default:
                        renglon = renglon.Replace("GAF(DataTypeName)", fila["DataTypeName"].ToString() + "(" + fila["ColumnSize"].ToString() + ")");

                        break;
                }
            }

            #region Sección de los IFs
            if (renglon.Contains("GAFIF(DataType)"))
            {
               
                switch (fila["DataType"].ToString())
                {
                    case "System.Int32":
                        renglon = renglon.Replace("GAFIF(DataType)", "0");
                        break;
                    case "System.Boolean":
                        renglon = renglon.Replace("GAFIF(DataType)", "False");
                        break;
                    case "System.String":
                        renglon = renglon.Replace("GAFIF(DataType)", "''");
                        break;
                    case "System.DateTime":
                        renglon = renglon.Replace("GAFIF(DataType)", "Nothing");
                        break;
                    case "System.Byte[]":
                        renglon = renglon.Replace("GAFIF(DataType)", "Nothing");
                        break;
                    default:
                        renglon = renglon.Replace("GAFIF(DataType)", "0");
                        break;
                }

            }
            #endregion

            return renglon;
        }
         private string RegresaPalabraReservada(string palabra)

        {   
            if (palabra.Contains("GAFIfInt32"))
                return "GAFIfInt32";

            if (palabra.Contains("GAFIfBoolean"))
                return "GAFIfBoolean";

            if (palabra.Contains("GAFIfString"))
                return "GAFIfString";

            if (palabra.Contains("GAFIfDateTime"))
                return "GAFIfDateTime";

            return "";
        }

        private void CrearArchivos()
        {
            AbrirConexion();

            CerrarConexion();
        }

        private void btnDirectorioEntrada_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                DialogResult dRes = fbd.ShowDialog();
                if (dRes == DialogResult.Cancel)
                {
                    return;
                }

                txtDirectorioEntrada.Text = fbd.SelectedPath + @"\";
               
            }


        }

        private void btnDirectorioSalida_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult dRes = fbd.ShowDialog();
                if (dRes == DialogResult.Cancel)
                {
                    return;
                }
                txtDirectorioSalida.Text = fbd.SelectedPath + @"\";
               
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Process.Start(Application.StartupPath + @"\HelpMe\Ayuda.html");
            }

            if (e.KeyCode == Keys.F2)
            {
                Process.Start(Application.StartupPath + @"\Templates\");
            }
        }
  
    }
}
