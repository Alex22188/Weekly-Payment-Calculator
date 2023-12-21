using System;
using System.Windows.Forms;
using System.Collections.Generic;

using System.IO;
using System.Globalization;
using CsvHelper;


using System.Security.Cryptography.X509Certificates;
using System.Linq;


using System.Net.Configuration;
using System.Net.NetworkInformation;

using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;






namespace OO_programming
{
    public partial class Form1 : Form
    {









        public Form1()
        {
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>






            






            TextBox1_Load();





        }





        private void TextBox1_Load()
        {

            string Path = @"C:\Users\alex4\Downloads\employee.csv";
            StreamReader reader = null;

            string employeeID = "Employee ID";
            string firstname = "First Name";
            string lastname = "Last Name";
          
            PaySlip EmployeeDetailList = new PaySlip(employeeID, firstname, lastname);
            EmployeeDetailList._EmployeeID = employeeID;
            EmployeeDetailList._FirstName = firstname;
            EmployeeDetailList._LastName = lastname;
          


            if (File.Exists(Path))
            {
                reader = new StreamReader(Path);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var Values = line.Split(',');
                    listBox1.Items.Add(employeeID);
                    listBox1.Items.Add(Values[0]);
                    listBox1.Items.Add(firstname);
                    listBox1.Items.Add(Values[1]);
                    listBox1.Items.Add(lastname);
                    listBox1.Items.Add(Values[2]);
                   




                }



            }



        }











        private void button1_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation to populate the
            // payment summary (textBox2) using the PaySlip and PayCalculatorNoThreshold
            // and classes object and methods.


            string employeeID = "Employee ID";

            string firstname = "First Name";
            string lastname = "Last Name";

            PaySlip EmployeeDetailsList = new PaySlip(employeeID, firstname, lastname);
            EmployeeDetailsList._EmployeeID = employeeID;
            EmployeeDetailsList._FirstName = firstname;
            EmployeeDetailsList._LastName = lastname;





            // PayCalculator class with objects for taxrate-nothreshold//
            string hoursworked = "Hours Worked:";
            string hourlyrate = "Hourly Rate:";
            string taxthreshold = "Taxthreshold:";
            string grosspay = "Gross Pay";
            string tax = "Tax";
            string netpay = "Net Pay:";
            string superannuation = "Superannuation:";




            //StreamReader used as reusable component - can use for other files//


            string Path = @"C:\Users\alex4\Downloads\employee.csv";
            StreamReader reader = null;

            if (File.Exists(Path))
            {


                reader = new StreamReader(Path);

                while (!reader.EndOfStream)
                {



                    var line = reader.ReadLine();

                    var Values = line.Split(',');



                    textBox2.AppendText($"{employeeID} {Values[0]} {firstname} {Values[1]} {lastname} {Values[2]}");




                    // PayCalculator class with objects for taxrate-nothreshold//
                    PayCalculator payCalculator = new PayCalculator();
                    payCalculator._HoursWorked = hoursworked;
                    payCalculator._HourlyRate = hourlyrate;
                    payCalculator._TaxThreshold = taxthreshold;
                    payCalculator._GrossPay = grosspay;
                    payCalculator._Tax = tax;
                    payCalculator._NetPay = netpay;
                    payCalculator._Supperannuation = superannuation;



                    string Path2 = @"C:\Users\alex4\Downloads\Cl_OOProgramming_AE_Pro_Appx (1)\Part 3 application files\taxrate-nothreshold.csv";
                    StreamReader reader1 = null;

                    reader1 = new StreamReader(Path2);

                    if (File.Exists(Path2))
                    {



                        while (!reader1.EndOfStream)
                        {


                            var line1 = reader1.ReadLine();
                            var Values1 = line1.Split(',');




                            //Method for working out gross pay and net pay//
                            //Hourly rate multiplied by hours worked = gross pay//
                            //Gross pay - tax = net pay//

                            //HoursWorked and HourlyRate and tax as a double converted into intergers as//
                            //csv data could not be converted from file//



                            int CsvDataHoursWorked = Convert.ToInt32(Values1[0]);
                            int CsvDataHourlyRate = Convert.ToInt32(Values1[1]);
                            double CsvTax = Convert.ToDouble(Values1[2]);


                            textBox2.Text += ($"{hoursworked} {Values1[0]} {hourlyrate} {Values1[1]} {grosspay} = {CsvDataHoursWorked * CsvDataHourlyRate} {tax} {Values1[2]} {netpay} = {CsvDataHoursWorked * CsvDataHourlyRate - CsvTax} {superannuation} {Values1[3]} \t\t\t\t\t");


                        }
                        break;


                    }


                }
            }

        }

                private void button2_Click(object sender, EventArgs e)
                {
                // Add code below to complete the implementation for saving the
                // calculated payment data into a csv file.

                // File naming convention: Pay_<full name>_<datetimenow>.csv
                // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation

                //This method is used to save the calculated data to csv file//

                TextWriter txt = new StreamWriter(@"C:\Users\alex4\Downloads\Form1-master\Form1-master\OO programming\Pay-EmployeeID-Fullname-{DateTImeNow}.csv");


                txt.Write(textBox2.Text);
                txt.Close();

                if (txt != null)
                {

                    MessageBox.Show("Save successful!");


                }
                else
                {
                    MessageBox.Show("Save not successful");
                }

            }


        }


            }
        

    





