package com.example.app.DataBase;

import android.provider.BaseColumns;

class HistorialDB {
    public static abstract class RegistroHistorial implements BaseColumns {
        //Título de la tabla final de historial
        public static final String TABLE_NAME = "Historiales";


        public static final String ID_USUARIO = "idUsuario";
        public static final String USUARIO = "nombreUsuario";




    }
}
