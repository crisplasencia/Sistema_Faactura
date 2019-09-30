using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Sistema_Facturacion1
{
    class TicketVenta
    {
        //Esto es un objeto para las lineas del ticket de venta
        StringBuilder linea = new StringBuilder();
        int maxD = 40, cortar;//Esto es asignando un limite a los caracteres de los numeros y la variable cortar cortara el texto cuando pase ese limite

        public string Lineasguion()
        {
            string Lineasguion = "";
            for (int i = 0; i < maxD; i++)
            {
                Lineasguion += "-"; // Lo que hice es que hace que agregue un guion hasta el limite de caracteres
            }
            return linea.AppendLine(Lineasguion).ToString();
        }
        public string LineasAsteriscos()
        {
            string LineasAsteriscos = "";
            for (int i = 0; i < maxD; i++)
            {
                LineasAsteriscos+= "*"; 
            }
            return linea.AppendLine(LineasAsteriscos).ToString();
        }
        public string LineasIgual()
        {
            string LineasIgual = "";
            for (int i = 0; i < maxD; i++)
            {
                LineasIgual += "=";
            }
            return linea.AppendLine(LineasIgual).ToString();
        }
        public void TituloDelTicket()
        {
            linea.AppendLine("ASIGNATURA           |CREDITO|PRECIO|VALOR");
        }
        // este metodo es para poner el texto a la izquierda
        public void Textoizquierda(string texto)
        {
            if (texto.Length > maxD)
            {
                //Esta variable nos indicara en que caracter se quedo al bajar el texto a la proxima fila
                int CaracterActual = 0;
                for (int longitudtexto = texto.Length; longitudtexto < maxD; longitudtexto -= maxD)
                {
                    //Se agrega las partes que salgan del texto 
                    linea.AppendLine(texto.Substring(CaracterActual, maxD));
                    CaracterActual += maxD;
                }
                //En este se agrega lo que queda
                linea.AppendLine(texto.Substring(CaracterActual, texto.Length - CaracterActual));
            }
            else
            {
                linea.AppendLine(texto);
            }
        }
        //La derecha
        public void Textoderecha(string texto)
        {
            if (texto.Length > maxD)
            {
                //Esta variable nos indicara en que caracter se quedo al bajar el texto a la proxima fila
                int CaracterActual = 0;
                for (int longitudtexto = texto.Length; longitudtexto < maxD; longitudtexto -= maxD)
                {
                    //Se agrega las partes que salgan del texto 
                    linea.AppendLine(texto.Substring(CaracterActual, maxD));
                    CaracterActual += maxD;
                }
                //esta variable es para poner los espacios que quedan 
                string espacios = "";

                // la obtencion de longitud del texto restante
                for (int i = 0; i < (maxD - texto.Substring(CaracterActual, texto.Length - CaracterActual).Length); i++)
                {
                    espacios += " ";
                }
                //En este se agrega lo que queda, y agrego los espacios antes del texto
                linea.AppendLine(espacios + texto.Substring(CaracterActual, texto.Length - CaracterActual));
            }
            else
            {
                string espacios = "";

                // la obtencion de longitud del texto restante
                for (int i = 0; i < (maxD - texto.Length); i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(espacios + texto);
            }
        }
        //Centro del texto
        public void CentrarTexto(string texto)
        {
            if (texto.Length > maxD)
            {
                //Esta variable nos indicara en que caracter se quedo al bajar el texto a la proxima fila
                int CaracterActual = 0;
                for (int longitudtexto = texto.Length; longitudtexto < maxD; longitudtexto -= maxD)
                {
                    //Se agrega las partes que salgan del texto 
                    linea.AppendLine(texto.Substring(CaracterActual, maxD));
                    CaracterActual += maxD;
                }
                //esta variable es para poner los espacios que quedan 
                string espacios = "";

                //Para centrar se saca la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxD - texto.Substring(CaracterActual, texto.Length - CaracterActual).Length) / 2;

                // la obtencion de longitud del texto restante
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";
                }
                //En este se agrega lo que queda, y agrego los espacios antes del texto
                linea.AppendLine(espacios + texto.Substring(CaracterActual, texto.Length - CaracterActual));
            }
            else
            {
                string espacios = "";

                //Para centrar se saca la cantidad de espacios libres y el resultado se divide entre dos
                int centrar = (maxD - texto.Length) / 2;

                // la obtencion de longitud del texto restante
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";
                }
                //En este se agrega lo que queda, y agrego los espacios antes del texto
                linea.AppendLine(espacios + texto);
            }
        }
        //Los Extremos
        public void TextosExtremos(string Textoizquierda, string Textoderecha)
        {
            string textoD, textoI, textoCompleto = ""; string espacios = "";
            //Si el texto que va a la izquierda es mayor que 18 se corta el texto 
            if (Textoizquierda.Length > 18)
            {
                cortar = Textoizquierda.Length - 18;
                textoI = Textoizquierda.Remove(18, cortar);
            }
            else
            {
                textoI = Textoizquierda;
            }
            textoCompleto = textoI;

            //En este caso si es mayor a 20 se corta
            if (Textoderecha.Length > 20)
            {
                cortar = Textoderecha.Length - 20;
                textoD = Textoderecha.Remove(20, cortar);
            }
            else
            {
                textoD = Textoderecha;

                int numEspacios = maxD - (textoI.Length + textoD.Length);
                for (int i = 0; i < numEspacios; i++)
                {
                    espacios += " "; 
                }
                textoCompleto += espacios + Textoderecha;
                //Se agrega la linea al ticket, al onjeto en si 
                linea.AppendLine(textoCompleto);
            }
        }
        //Totales de la venta 
        public void VentaTotal(string texto, decimal total)
        {
            string resumen, valor, textoCompleto, espacios = "";

            if (texto.Length >25 )
            {
                cortar = texto.Length - 25;
                resumen = texto.Remove(25, cortar);
            }
            else
            {
                resumen = texto;
            }
            textoCompleto = resumen;
            valor = total.ToString("#,#.00");

            //numero de espacios restantes para alinearlos a la derecha
            int numEspacios = maxD - (resumen.Length + valor.Length);

            //Ahora los espacios
            for (int i = 0; i < numEspacios; i++)
            {
                espacios += "";
            }
            textoCompleto += espacios + valor;
            linea.AppendLine(textoCompleto);
        }
        //Agregar Articulos al Ticket
        public void AgregarArticulos(string articulo, int cantidad, decimal precio, decimal dev)
        {
            //esta valida la cantidad y las dev que esten dentro del rango 
            if (cantidad.ToString().Length <= 5 && precio.ToString().Length <= 7 && dev.ToString().Length <= 8 )
            {
                string elemento = " "; string espacios = " ";
                //nos indica si la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera
                bool platano = false;
                int numEspacios = 0;

                //se muestra si el nombre del articulo es mayor a 20, bajara a la segunda linea
                if (articulo.Length > 20)
                {
                    // la cantidad se mostrara a la derecha
                    numEspacios = (5 - cantidad.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "    ";
                    }
                    elemento += espacios + cantidad.ToString();

                    //el precio se mostrara a la derecha
                    numEspacios = (7 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "    ";
                    }
                    elemento += espacios + precio.ToString();

                    //la Dev se mostrara a la derecha
                    numEspacios = (8 - dev.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "    ";
                    }
                    elemento += espacios + dev.ToString();

                    //indica en que caracter se quedo al bajar a la siguiente linea
                    int caracterActual = 0;

                    //por cada 20 caracteres se agregarara otra linea
                    for (int longitudtexto = articulo.Length; longitudtexto < 20; longitudtexto -= 20)
                    {
                        //si es falsa o la primera linea recorre, continuara
                        if (platano == false) 
                        {
                            //Se agregan los primeros 20 caracteres del nombre del articulo + el que ya tiene 
                            linea.AppendLine(articulo.Substring(caracterActual, 20) + elemento);
                            //el valor cambia a verdadero
                            platano = true;
                        }
                        else
                        {
                            linea.AppendLine(articulo.Substring(caracterActual, 20));
                            caracterActual += 20;
                        }
                        linea.AppendLine(articulo.Substring(caracterActual, articulo.Length - caracterActual));
                    }
                }
                //si no es mayor solo se agrega, sin dar saltos de linea
                else
                {
                    for (int i = 0; i < (20 - articulo.Length); i++)
                    {
                        espacios += " ";
                    }
                    elemento = articulo + espacios;

                    //se coloca la cantidad del lado derecho
                    numEspacios = (5 - cantidad.ToString().Length);
                    espacios = "  ";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "";
                    }
                    elemento += espacios + cantidad.ToString();

                    //se coloca el precio del lado derecho
                    numEspacios = (7 - precio.ToString().Length);
                    espacios = "   ";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "";
                    }
                    elemento += espacios + precio.ToString();

                    //se coloca la Dev del lado derecho
                    numEspacios = (8 - dev.ToString().Length);
                    espacios = "    ";
                    for (int i = 0; i < numEspacios; i++)
                    {
                        espacios += "";
                    }
                    elemento += espacios + dev.ToString();

                    //Se agrega todo al elemento: articulo, cantidad, precio, dev
                    linea.AppendLine(elemento);
                }

            }

        }
        //metodo de impresion 
        public void Cortaticket()
        {
            linea.AppendLine("\x1B" + "m");
            linea.AppendLine("\x1B" + "d" + "\x09");

        }
        public void Imprimirticket(string impresora)
        {
            RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString());
            linea.Clear();
        }
        //Imprimir 
        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "Ticket de Venta";//Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
                di.pDataType = "RAW";//de tipo texto plano

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }



    }
}
