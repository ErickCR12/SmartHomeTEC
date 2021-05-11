package com.example.app.DataBase

import android.content.ContentValues


class Aposentos(var idUsuario: Int, var nombreUsuario: String, var nombreAposento: String){

    fun toContentValues(): ContentValues?{
        val values = ContentValues()
        //Valores relacionados al usuario
        values.put(AposentosDB.RegistroAposentos.ID_USUARIO, idUsuario)
        values.put(AposentosDB.RegistroAposentos.USUARIO, nombreUsuario)
        //Valores relacionados a los apentos
        values.put(AposentosDB.RegistroAposentos.APOSENTO, nombreAposento)

        return  values
    }
}