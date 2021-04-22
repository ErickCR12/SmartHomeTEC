package com.example.app.Especiales

import android.app.DatePickerDialog
import android.app.Dialog
import android.content.Context
import android.icu.util.Calendar
import android.os.Build
import android.os.Bundle
import android.widget.DatePicker
import androidx.annotation.RequiresApi
import androidx.fragment.app.DialogFragment

//Se trabaja la selección de la fecha enviando los parámetros de día, mes y año
class SeleccionFecha(val listener: (dia:Int, mes:Int, anO:Int)-> Unit): DialogFragment(),
        DatePickerDialog.OnDateSetListener {

    //Se invoca a la función de Selección cuando el usuario haga selección
    override fun onDateSet(view: DatePicker?, year: Int, month: Int, dayOfMonth: Int) {
        listener(dayOfMonth, month, year)
    }

    @RequiresApi(Build.VERSION_CODES.N)
    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {

        //Se trabaja con el feature de Calendar de java.util, esto es importante
        //Se trabaja con getInstance para obtener la información seleccionada
        val calendario:java.util.Calendar = java.util.Calendar.getInstance()

        //Según la selección del usuario se toma el día, mes y año
        val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
        val mes = calendario.get(java.util.Calendar.MONTH)
        val ano = calendario.get(java.util.Calendar.YEAR)

        //Se fijan los datos seleccionados
        val picker = DatePickerDialog( activity as Context, this, ano, mes, dia)
        //Se crea un límite de fecha actual para poder hacer la selcción de fecha
        picker.datePicker.maxDate = calendario.timeInMillis
        return picker
    }
}