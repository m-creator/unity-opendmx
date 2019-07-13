using System;
using System.Runtime.InteropServices;


public class FTDI_D2XX
{
    public const byte BITS_8 = 8;
    public const byte STOP_BITS_2 = 2;
    public const byte PARITY_NONE = 0;
    public const UInt16 FLOW_NONE = 0;
    public const byte PURGE_RX = 1;
    public const byte PURGE_TX = 2;


    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_Open(UInt32 uiPort, ref uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_Close(uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_Read(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesReturned);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_Write(uint ftHandle, IntPtr lpBuffer, UInt32 dwBytesToRead, ref UInt32 lpdwBytesWritten);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_SetDataCharacteristics(uint ftHandle, byte uWordLength, byte uStopBits, byte uParity);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_SetFlowControl(uint ftHandle, char usFlowControl, byte uXon, byte uXoff);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_GetModemStatus(uint ftHandle, ref UInt32 lpdwModemStatus);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_Purge(uint ftHandle, UInt32 dwMask);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_ClrRts(uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_SetBreakOn(uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_SetBreakOff(uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_GetStatus(uint ftHandle, ref UInt32 lpdwAmountInRxQueue, ref UInt32 lpdwAmountInTxQueue, ref UInt32 lpdwEventStatus);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_ResetDevice(uint ftHandle);
    [DllImport("FTD2XX.dll")]
    public static extern FT_STATUS FT_SetDivisor(uint ftHandle, char usDivisor);
}

/// <summary>
/// Enumaration containing the varios return status for the DLL functions.
/// </summary>
public enum FT_STATUS
{
    FT_OK = 0,
    FT_INVALID_HANDLE,
    FT_DEVICE_NOT_FOUND,
    FT_DEVICE_NOT_OPENED,
    FT_IO_ERROR,
    FT_INSUFFICIENT_RESOURCES,
    FT_INVALID_PARAMETER,
    FT_INVALID_BAUD_RATE,
    FT_DEVICE_NOT_OPENED_FOR_ERASE,
    FT_DEVICE_NOT_OPENED_FOR_WRITE,
    FT_FAILED_TO_WRITE_DEVICE,
    FT_EEPROM_READ_FAILED,
    FT_EEPROM_WRITE_FAILED,
    FT_EEPROM_ERASE_FAILED,
    FT_EEPROM_NOT_PRESENT,
    FT_EEPROM_NOT_PROGRAMMED,
    FT_INVALID_ARGS,
    FT_OTHER_ERROR
};