﻿using UnityEngine;
using UnityEngine.UI;
using SpeechLib;
using System;
using System.Collections;

public class TaxCalculator : MonoBehaviour
{

   


    // Constant rate for the Medicare Levy
    const double MEDICARE_LEVY = 0.02;

    // Variables
    bool textToSpeechEnabled = true;
    public InputField grossSalaryInputField;
    public Dropdown timeframe;
    public InputField grossYearlySalaryImputField;

    private void Start()
    {
        Speak("Welcome to the A.T.O. Tax Calculator");
    }

    // Run this function on the click event of your 'Calculate' button

    public void Calculate()
    {
        
            
        // Initialisation of variables
        double medicareLevyPaid = 0;
        double incomeTaxPaid = 0;

        // Input
        double grossSalaryInput = GetGrossSalary();
        string salaryPayPeriod = GetSalaryPayPeriod();

        // Calculations
        double grossYearlySalary = CalculateGrossYearlySalary(grossSalaryInput, salaryPayPeriod);
        double netIncome = CalculateNetIncome(grossYearlySalary, ref medicareLevyPaid, ref incomeTaxPaid);

        // Output
        OutputResults(medicareLevyPaid, incomeTaxPaid, netIncome);
    }

    private double GetGrossSalary()
    {
        // Get from user. E.g. input box
        // Validate the input (ensure it is a positive, valid number)


        double grossSalary = double.Parse(grossSalaryInputField.text);
        print(grossSalary);
        return grossSalary;
    }

    private string GetSalaryPayPeriod()
    {
        // Get from user. E.g. combobox or radio buttons
        
        int salaryPayPeriod = timeframe.value;

        if (salaryPayPeriod == 0) return"weekly";
        else if (salaryPayPeriod == 1) return"fortnightly" ;
        else if (salaryPayPeriod == 2) return"monthly" ;
        else return "yearly";
    }

    private double CalculateGrossYearlySalary(double grossSalaryInput, string salaryPayPeriod)
    {

        if (salaryPayPeriod == "weekly") return grossSalaryInput * 52;
        else if (salaryPayPeriod == "fortnightly") return grossSalaryInput * 26;
        else if (salaryPayPeriod == "monthly") return grossSalaryInput * 12;
        else return grossSalaryInput;
    }

    private double CalculateNetIncome(double grossYearlySalary, ref double medicareLevyPaid, ref double incomeTaxPaid)
    {
        // This is a stub, replace with the real calculation and return the result
        medicareLevyPaid = CalculateMedicareLevy(grossYearlySalary);
        incomeTaxPaid = CalculateIncomeTax(grossYearlySalary);
        double netIncome = grossYearlySalary - incomeTaxPaid - medicareLevyPaid ;        
        return netIncome;
    }

    private double CalculateMedicareLevy(double grossYearlySalary)
    {
        // This is a stub, replace with the real calculation and return the result
        double medicareLevyPaid = 2000;        
        return medicareLevyPaid;
    }

    private double CalculateIncomeTax(double grossYearlySalary)
    {
        // This is a stub, replace with the real calculation and return the result
        double incomeTaxPaid = 15000;
        return incomeTaxPaid;
    }

    private void OutputResults(double medicareLevyPaid, double incomeTaxPaid, double netIncome)
    {
        // Output the following to the GUI
        // "Medicare levy paid: $" + medicareLevyPaid.ToString("F2");
        // "Income tax paid: $" + incomeTaxPaid.ToString("F2");
        // "Net income: $" + netIncome.ToString("F2");
    }

    // Text to Speech
    private void Speak(string textToSpeak)
    {
        if(textToSpeechEnabled)
        {
            SpVoice voice = new SpVoice();
            voice.Speak(textToSpeak);
        }
    }
}
