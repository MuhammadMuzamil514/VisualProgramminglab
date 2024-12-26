using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace AppointmentApp
{
    public partial class MainWindow : Window
    {
        // List to store the appointments
        public List<Appointment> Appointments { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Appointments = new List<Appointment>();
            LoadAppointments();  // Load data from database
        }

        // Method to load appointments from the database
        private void LoadAppointments()
        {
            // Define your SQL connection string
            string connectionString = @"Server=DESKTOP-06NJIOH\SQLEXPRESS;Database=patient;Trusted_Connection=True;";

            // SQL query to join the tables and retrieve appointment details
            string query = "SELECT a.AID, p.Name AS PatientName, d.Name AS DoctorName, a.AppointmentDate, a.AppointmentTime " +
                           "FROM Appointment a " +
                           "JOIN Patient p ON a.PID = p.PID " +
                           "JOIN Doctor d ON a.DID = d.DID";

            try
            {
                // Establish the database connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Execute the query and get the data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Read each row from the query result and create Appointment objects
                    while (reader.Read())
                    {
                        var appointment = new Appointment
                        {
                            AID = reader.GetInt32(0),               // Appointment ID
                            PatientName = reader.GetString(1),      // Patient Name
                            DoctorName = reader.GetString(2),       // Doctor Name
                            AppointmentDate = reader.GetDateTime(3), // Appointment Date
                            AppointmentTime = reader.GetTimeSpan(4)  // Appointment Time
                        };

                        // Add the appointment to the list
                        Appointments.Add(appointment);
                    }

                    // Close the reader after use
                    reader.Close();
                }

                // Bind the data to the DataGrid (UI element)
                appointmentsDataGrid.ItemsSource = Appointments;
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., connection issues)
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    // Appointment class representing appointment data
    public class Appointment
    {
        public int AID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
    }
}
