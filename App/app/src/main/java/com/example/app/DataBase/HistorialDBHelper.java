package com.example.app.DataBase;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.Build;

import androidx.annotation.RequiresApi;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class HistorialDBHelper extends SQLiteOpenHelper {


    public static final int DATABASE_VERSION =1;
    public static final String DATABASE_NAME = "Historiales.db";

    @Override
    public SQLiteDatabase getReadableDatabase(){
        return  super.getReadableDatabase();
    }

    public HistorialDBHelper(Context context){
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL("CREATE TABLE " + HistorialDB.RegistroHistorial.TABLE_NAME + " ("
                + HistorialDB.RegistroHistorial.ID_USUARIO + " INTEGER,"
                + HistorialDB.RegistroHistorial.USUARIO + " TEXT NOT NULL,"
                + "UNIQUE (" + HistorialDB.RegistroHistorial.ID_USUARIO+ "))"
        );
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
    }

    public void  crearHistoral(SQLiteDatabase db, Historial historial){
        db.insert(
                HistorialDB.RegistroHistorial.TABLE_NAME,
                null,
                historial.toContentValues());
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    public List<Historial> getListaHistorial(Integer id){
        ArrayList<Historial> lista = new ArrayList<Historial>();
        Cursor cursor = getReadableDatabase()
                .rawQuery("SELECT * FROM Historiales WHERE idUsuario == ?", new String[]{id.toString()});
        if (cursor.moveToFirst()){
            do{
                Historial historial = new Historial(
                        //Usuario
                        cursor.getInt(cursor.getColumnIndex("idUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreUsuario")));
                lista.add(historial);
            }while (cursor.moveToNext());
        }
        return lista;
    }

    public int updateRegistro(Historial historial, Integer idHistorial){
        return getWritableDatabase().update(
                AposentosDB.RegistroAposentos.TABLE_NAME,
                historial.toContentValues(),
                AposentosDB.RegistroAposentos.ID_USUARIO + "LIKE ?",
                new String[]{idHistorial.toString()}
        );
    }

    @RequiresApi(api = Build.VERSION_CODES.O)
    public Historial obtenerHistorial(Integer id) {
        Historial historial = null;
        Cursor cursor =  getReadableDatabase()
                .rawQuery("SELECT * FROM Historiales WHERE idUsuario == ?", new String[]{id.toString()});
        if (cursor.moveToFirst()) {
            do {
                historial = new Historial(//Usuario
                        //Usuario
                        cursor.getInt(cursor.getColumnIndex("idUsuario")),
                        cursor.getString(cursor.getColumnIndex("nombreUsuario")));
            } while (cursor.moveToNext());
        }
        return historial;
    }
}
