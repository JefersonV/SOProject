using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SOProject
{
    public partial class Btn_Detener : Form
    {
        //Declaracion de variable string para obtener el nombre del proceso en la tabla para su eliminacion
        string Str_Obt_Proc;
        public Btn_Detener()
        {
            InitializeComponent();
            ActualizarTabla();
            timer1.Enabled = true;
        }

        private void ActualizarTabla()
        {
            //limpieza del datagrid
            dgv_Proceso.Rows.Clear();
            //creacion columnas con sus respectivos nombres
            dgv_Proceso.Columns[0].Name = "Num. Procesos";
            dgv_Proceso.Columns[1].Name = "Procesos";
            dgv_Proceso.Columns[2].Name = "Prioridad Proceso";
            dgv_Proceso.Columns[3].Name = "ID";
            dgv_Proceso.Columns[4].Name = "Memoria Fisica";
            dgv_Proceso.Columns[5].Name = "Memoria Virtual";


            //Propiedad para autoajustar el tamaño de las celdas segun su contenido
            dgv_Proceso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Propiedad para que el usuario seleccione solamente filas en la tabla y no celdas sueltas
            dgv_Proceso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Propiedad para que el usuario no pueda seleccionar mas de una fila
            dgv_Proceso.MultiSelect = false;

            //Declaracion de la variable que sera un contador para el total de procesos
            int Int_Cant_Proc = 1;


            foreach (Process Proc_Proceso in Process.GetProcesses())
            {
                //Ingreso de los datos en el datagrid
                dgv_Proceso.Rows.Add(Int_Cant_Proc, Proc_Proceso.ProcessName, Proc_Proceso.BasePriority, Proc_Proceso.Id, Proc_Proceso.WorkingSet64,
                    Proc_Proceso.VirtualMemorySize64);
                //aumento en 1 de la variable
                Int_Cant_Proc += 1;
            }
            //El label muestra la cantidad de procesos actuales
            lbl_Contador.Text = "Procesos Actuales: " + (Int_Cant_Proc - 1);    //  cant de procesos   


        } 

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Ocultamos todos los objetos para los graficos y mostramos solo el Dgv de Procesos
            /*LblNombreCPU.Visible = false;
            LblNombreRam.Visible = false;
            ProgressBarCPU.Visible = false;
            ProgressBarRAM.Visible = false;
            LblPorCPU.Visible = false;
            LblPorRAM.Visible = false;
            Grafico.Visible = false;
            dgv_Proceso.Visible = true;
            */
            // No vamos a usar los gráficos
            //Llamado al proceso para actualizar la tabla
            ActualizarTabla();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                //Por cada proceso que haya se comparara su nombre con el nombre del proceso que se desea eliminar.
                foreach (Process proceso in Process.GetProcesses())
                {
                    if (proceso.ProcessName == Str_Obt_Proc)
                    {
                        proceso.Kill();//Se elimina el proceso
                        ActualizarTabla();//Se llama al proceso para actualizar la tabla automaticamente
                    }
                }

            }
            //En caso no se seleccione un proceso mostrara el siguiente mensaje.
            catch (Exception x)
            {
                MessageBox.Show("No se ha seleccionado ningun proceso para detener." + x, "Error al Detener Proceso", MessageBoxButtons.OK);
            }
        }

        private void dgv_Proceso_MouseClick(object sender, MouseEventArgs e)
        {
            //La variable obtiene el Nombre del Proceso de la Tabla al hacerle clic
            Str_Obt_Proc = dgv_Proceso.SelectedRows[0].Cells[1].Value.ToString();
        }

        // A partir de la linea 125 ya no, porque era para la gráfica y CPU

    }
}
