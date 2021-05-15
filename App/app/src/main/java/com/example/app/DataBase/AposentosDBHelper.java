package com.example.app.DataBase;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Build;
import android.util.Log;

import androidx.annotation.RequiresApi;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class AposentosDBHelper extends SQLiteOpenHelper {

    public static final int DATABASE_VERSION =1;
    public static final String DATABASE_NAME = "Aposentos.db";

    @Override
    public SQLiteDatabase getReadableDatabase(){
        return  super.getReadableDatabase();
    }

    public AposentosDBHelper(Context context){
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL("CREATE TABLE " + AposentosDB.RegistroAposentos.TABLE_NAME + " ("
                + AposentosDB.RegistroAposentos.ID_USUARIO + " INTEGER,"
                + AposentosDB.RegistroAposentos.USUARIO + " TEXT NOT NULL,"
                + AposentosDB.RegistroAposentos.APOSENTO + " TEXT NOT NULL,"
                + "UNIQUE (" + AposentosDB.RegistroAposentos.APOSENTO+ "))"
        );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
    }

    public void  crearAposento(SQLiteDatabase db, Aposentos aposentos){
        db.insert(
                AposentosDB.RegistroAposentos.TABLE_NAME,
                null,
                aposentos.toContentValues());
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    public List<Aposentos> getListaAposentos(Integer id){
        ArrayList<Aposentos> lista = new ArrayList<Aposentos>();
        Cursor cursor = getReadableDatabase()
                .rawQuery("SELECT * FROM Aposentos WHERE idUsuario == ?", new String[]{id.toString()});
        if (cursor.moveToFirst()){
            do{
                Aposentos aposentos = new Aposentos(
                        //Usuario
                        cursor.getInt(cursor.getColumnIndex("idUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreUsuario")),
                        //Dispositivo
                        cursor.getString(cursor.getColumnIndex("nombreAposento")));

                aposentos.setIdUsuario(cursor.getColumnIndex("idUsuario"));
                lista.add(aposentos);
            }while (cursor.moveToNext());
        }
        return lista;
    }

    public int updateAposento(Aposentos aposentos, Integer idUsuario){
        return getWritableDatabase().update(
                AposentosDB.RegistroAposentos.TABLE_NAME,
                aposentos.toContentValues(),
                AposentosDB.RegistroAposentos.ID_USUARIO + "LIKE ?",
                new String[]{idUsuario.toString()}
        );
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    public Aposentos obtenerAposento(Integer id) {
        Aposentos aposentos = null;
        Cursor cursor =  getReadableDatabase()
                .rawQuery("SELECT * FROM Aposentos WHERE idUsuario == ?", new String[]{id.toString()});
        if (cursor.moveToFirst()) {
            do {
                aposentos = new Aposentos(//Usuario
                        cursor.getInt(cursor.getColumnIndex("idUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreUsuario")),
                        //Dispositivo
                        cursor.getString(cursor.getColumnIndex("nombreAposento")));
            } while (cursor.moveToNext());
        }

        return aposentos;
    }
}
