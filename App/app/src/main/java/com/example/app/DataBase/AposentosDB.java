package com.example.app.DataBase;

import android.provider.BaseColumns;

class AposentosDB {

    public static abstract class RegistroAposentos implements BaseColumns {

        //Título de la tabla final de aposentos
        public static final String TABLE_NAME = "Aposentos";

        //Relacionado al usuario
        public static final String ID_USUARIO = "idUsuario";
        public static final String USUARIO = "nombreUsuario";

        //Relacionados a los aposentos
        public static final String APOSENTO ="nombreAposento";
    }
}
