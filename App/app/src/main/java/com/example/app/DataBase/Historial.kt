package com.example.app.DataBase

import android.content.ContentValues

class Historial (var dispositivo: String, var tiempo: Int, var fecha: String) {

        fun toContentValues(): ContentValues?{
            val values = ContentValues()

            values.put(HistorialDB.RegistroHistorial.DISPOSITIVO, dispositivo)
            values.put(HistorialDB.RegistroHistorial.TIEMPO, tiempo)
            values.put(HistorialDB.RegistroHistorial.FECHA, fecha)

            return  values
        }
}