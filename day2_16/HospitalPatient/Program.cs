using System;
using System.Net.Mime;
using System.Collections.Generic;
public class Patient
{
    public int Id {get; set;}
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }
    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
    }
}
public class HospitalManager
{
    private Dictionary<int, Patient> patients = new Dictionary<int, Patient>();
    private Queue<Patient> appointmentQueue = new Queue<Patient>();
    
    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        // TODO: Create patient and add to dictionary
        patients[id] = new Patient(id,name,age,condition);
    }
    
    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue
        appointmentQueue.Enqueue(patients[patientId]);
    }
    
    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        // TODO: Return and remove next patient from queue
        if (appointmentQueue.Count() > 0)
        {
            var nextPatient = appointmentQueue.Peek();
            appointmentQueue.Dequeue();
            return nextPatient;
        }
        return null;
    }
    
    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        // TODO: Use LINQ to filter patients
        List<Patient> PatientList = patients.Values.Where(n=>n.Condition==condition).ToList();
        return PatientList;
    }
}
public class Program
{
    public static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name); // Should output: John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count); // Should output: 1

    }
}