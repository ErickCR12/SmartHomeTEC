package com.example.app.DataBase

import android.content.ContentValues
import java.time.LocalDateTime

class Historial (var dispositivo: String, var tiempo: Int, var fecha: LocalDateTime, var estado: Boolean) {

        fun toContentValues(): ContentValues?{
            val values = ContentValues()

            values.put(HistorialDB.RegistroHistorial.DISPOSITIVO, dispositivo)
            values.put(HistorialDB.RegistroHistorial.TIEMPO, tiempo)
            values.put(HistorialDB.RegistroHistorial.FECHA, fecha.toString())
            values.put(HistorialDB.RegistroHistorial.ESTADO, estado)

            return  values
        }
}