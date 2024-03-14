namespace Agend
{
    public partial class Form1 : Form
    {
        // Declarar una lista para almacenar los CheckBox creados dinámicamente
        private List<CheckBox> dynamicCheckBoxes = new List<CheckBox>();

        // Variable para indicar si se encuentra en modo de eliminación
        private bool deleteMode = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // Pedir al usuario que ingrese el texto para el nuevo CheckBox
            string checkBoxText = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el texto para el nuevo CheckBox:", "Nuevo CheckBox", "Texto predeterminado");

            // Verificar si el usuario ingresó algún texto
            if (!string.IsNullOrEmpty(checkBoxText))
            {
                // Crear un nuevo CheckBox
                CheckBox newCheckBox = new CheckBox();

                // Establecer el texto ingresado por el usuario
                newCheckBox.Text = checkBoxText;
                newCheckBox.AutoSize = true;

                // Calcular la posición del nuevo CheckBox
                int newX = 20; // Cambiar la coordenada X
                int newY = 70;  // Cambiar la coordenada Y
                if (dynamicCheckBoxes.Count > 0)
                {
                    // Si hay CheckBoxes dinámicos creados, alinear el nuevo con el último creado
                    newX = dynamicCheckBoxes[dynamicCheckBoxes.Count - 1].Left;
                    newY = dynamicCheckBoxes[dynamicCheckBoxes.Count - 1].Top + dynamicCheckBoxes[dynamicCheckBoxes.Count - 1].Height + 10;
                }

                // Establecer la posición del nuevo CheckBox
                newCheckBox.Location = new System.Drawing.Point(newX, newY);

                // Agregar el nuevo CheckBox a la lista y al formulario
                dynamicCheckBoxes.Add(newCheckBox);
                newCheckBox.Click += CheckBox_Click; // Agregar el manejador de eventos Click
                this.Controls.Add(newCheckBox);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Cambiar el estado del modo de eliminación
            deleteMode = !deleteMode;

            // Cambiar el texto del botón según el modo actual
            deleteButton.Text = deleteMode ? "Cancelar Eliminar" : "Eliminar";

            // Cambiar el color de fondo del botón según el modo actual
            deleteButton.BackColor = deleteMode ? System.Drawing.Color.Red : System.Drawing.SystemColors.Control;

            // Cambiar el cursor para indicar el modo actual
            this.Cursor = deleteMode ? Cursors.Cross : Cursors.Default;
        }
        private void CheckBox_Click(object sender, EventArgs e)
        {
            // Verificar si está en modo de eliminación
            if (deleteMode)
            {
                // Obtener el CheckBox que ha sido clickeado
                CheckBox clickedCheckBox = sender as CheckBox;

                // Eliminar el CheckBox de la lista y del formulario
                dynamicCheckBoxes.Remove(clickedCheckBox);
                this.Controls.Remove(clickedCheckBox);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
