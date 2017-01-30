using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionExample
{
    public partial class Form1 : Form
    {
        private string assemblyPath="";
        Assembly assembly = null;
        List<Type> listOfClassTypes = null;
        string accesMethodType = "";
        object obj;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnLoadAssembly_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Dll |*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                assemblyPath = ofd.FileName;
                assembly = Assembly.LoadFrom(assemblyPath);
                //MessageBox.Show(assembly.ToString());
                listOfClassTypes = new List<Type>();
                foreach(Type type in assembly.DefinedTypes)
                {
                    if (type.IsClass)
                    {
                        listOfClassTypes.Add(type.GetTypeInfo());
                        cbxClassName.Items.Add(type.FullName);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type type = obj.GetType();
            if(accesMethodType.Equals(""))
            {
                tbxResult.Text = "";
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    tbxResult.Text += String.Format("Name: {0} | ReturnType: {1} ", methodInfo.Name, methodInfo.ReturnType);
                    foreach (ParameterInfo param in methodInfo.GetParameters())
                    {
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += "Parameters: ";
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += String.Format("ParamName: {0} | ParamType {1} ", param.Name, param.ParameterType);
                    }
                    tbxResult.Text += Environment.NewLine;
                }
                
            }
            else if(accesMethodType.Equals("Public"))
            {
                tbxResult.Text = "";
                foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    tbxResult.Text += String.Format("Name: {0} | ReturnType: {1} ", methodInfo.Name, methodInfo.ReturnType);
                    foreach (ParameterInfo param in methodInfo.GetParameters())
                    {
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += "Parameters: ";
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += String.Format("ParamName: {0} | ParamType {1} ", param.Name, param.ParameterType);
                    }
                    
                }
                
            } else if(accesMethodType.Equals("NonPublic"))
            {
                tbxResult.Text = "";
                foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    tbxResult.Text += String.Format("Name: {0} | ReturnType: {1}", methodInfo.Name, methodInfo.ReturnType);
                    foreach (ParameterInfo param in methodInfo.GetParameters())
                    {
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += "Parameters: ";
                        tbxResult.Text += Environment.NewLine;
                        tbxResult.Text += String.Format("ParamName: {0} | ParamType {1} ", param.Name, param.ParameterType);
                    }
                    tbxResult.Text += Environment.NewLine;
                }
            }
           
        }

        private void cbxClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
           foreach(Type t in listOfClassTypes)
            {
                if(cbxClassName.SelectedItem.Equals(t.FullName.ToString()))
                {
                    try
                    {
                        obj = Activator.CreateInstance(t);
                        
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                   
                }

            }
            
        }

        private void cbxAccesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            accesMethodType = cbxAccesType.SelectedItem.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Type t = obj.GetType();
            tbxResult.Text = "";
            foreach (FieldInfo fieldInfo in t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                tbxResult.Text += Environment.NewLine;
                tbxResult.Text += String.Format("Name: {0} | Type: {1} | Value: {2}", fieldInfo.Name, fieldInfo.FieldType, fieldInfo.GetValue(obj));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Type t = obj.GetType();
            tbxResult.Text = "";
            foreach (PropertyInfo propInfo in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                tbxResult.Text += Environment.NewLine;
                tbxResult.Text += String.Format("Name: {0} | Type: {1} | Value: {2}", propInfo.Name, propInfo.PropertyType, propInfo.GetValue(obj));
            }
        }
    }
}
