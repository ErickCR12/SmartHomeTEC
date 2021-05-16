package com.example.app.DataBase

import android.content.ContentValues
import java.time.LocalDateTime

class Historial (var idUsuario: Int, var Usuario: String) {

        fun toContentValues(): ContentValues?{
            val values = ContentValues()

            values.put(HistorialDB.RegistroHistorial.ID_USUARIO, idUsuario)
            values.put(HistorialDB.RegistroHistorial.USUARIO, Usuario)
            return  values
        }
}