using System;
using System.Runtime.InteropServices;
using UnityEngine;


public class OpenDmx
{
	private uint port = 0;
	private int device_number = -1;
	
	
	public OpenDmx(int device_number)
	{
		this.device_number = device_number;
		open();
	}
	
	private void open()
	{
		uint port_ref = 0;
		int res = 0;
		
		res = (int)FTDI_D2XX.FT_Open((UInt32)this.device_number, ref port_ref);
		checkRes(res);
		port = port_ref;
		
		res = (int)FTDI_D2XX.FT_ResetDevice(port);
    	checkRes(res);
    	
    	res = (int)FTDI_D2XX.FT_SetDivisor(port, (char)12);
    	checkRes(res);
    	
    	res = (int)FTDI_D2XX.FT_SetDataCharacteristics(port, FTDI_D2XX.BITS_8, FTDI_D2XX.STOP_BITS_2, FTDI_D2XX.PARITY_NONE);
    	checkRes(res);
    	
    	res = (int)FTDI_D2XX.FT_SetFlowControl(port, (char)FTDI_D2XX.FLOW_NONE, (byte)0, (byte)0);
	    checkRes(res);
	    res = (int)FTDI_D2XX.FT_ClrRts(port);
	    checkRes(res);
	    res = (int)FTDI_D2XX.FT_Purge(port, (char)FTDI_D2XX.PURGE_TX);
	    checkRes(res);
	    res = (int)FTDI_D2XX.FT_Purge(port, (char)FTDI_D2XX.PURGE_RX);
	    checkRes(res);
	}
	
	public int close()
	{
		return (int)FTDI_D2XX.FT_Close(port);
	}
	
	public int sendData(byte[] data, int len_data) {
	    /*
		if (port != 0)
	    {
	    	UnityEditor.EditorApplication.isPlaying = false;
	    }
	    if(len_data >= 0 && len_data <= 512){
	    	UnityEditor.EditorApplication.isPlaying = false;
	    }
	    */
	    
	    FTDI_D2XX.FT_SetBreakOn(port);
	    FTDI_D2XX.FT_SetBreakOff(port);
	    
	    uint written = 0;
	    
	    IntPtr ptr1 = Marshal.AllocHGlobal(1);
	    byte[] code = {0};
	    Marshal.Copy(code, 0, ptr1, 1);
	    int res = (int)FTDI_D2XX.FT_Write(port, ptr1, (uint)1, ref written);
        checkRes(res);
        IntPtr ptr2 = Marshal.AllocHGlobal((int)len_data);
	    Marshal.Copy(data, 0, ptr2, (int)len_data);
        res = (int)FTDI_D2XX.FT_Write(port, ptr2, (uint)len_data, ref written);
        checkRes(res);
	    
	    return res;
	  }
	
	private void checkRes(int res)
	{
    	if (res != (int)FT_STATUS.FT_OK) {
      		//Debug.Log("problem! check FTDI_D2XX.java for error code info. code: " + res);
    	}
  	}
}
