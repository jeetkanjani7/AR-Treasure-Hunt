package com.LNMIIT.TreasureHunt;



import android.location.Location;
import sun.applet.Main;
import android.app.Activity;
import android.content.Context;

public class Communicate extends MyLocation {
	public double lat=0,lon=0;
	//
	LocationResult locationResult = new LocationResult(){
    @Override
    public void gotLocation(Location location){
        lat=location.getLatitude();
        lon=location.getLongitude();
        
    }
    
   // applicationContext=this;
	};

	public double getlatitude()
	{
		
		return lat;
	}

	public double getlongitude()
	{
		return lon;
	}
	
public  void init() {
	

	
	

	android.app.Activity act=new Activity();
	 Context context=act.getApplicationContext();
	Communicate communicate= new Communicate();
	MyLocation myLocation = new MyLocation();
	myLocation.getLocation(context, communicate.locationResult);
}
}