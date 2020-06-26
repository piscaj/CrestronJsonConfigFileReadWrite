using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using jsFetch;

namespace UserModule_JSONFETCH_V1_0
{
    public class UserModuleClass_JSONFETCH_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITILIZEFILESYSTEM;
        Crestron.Logos.SplusObjects.DigitalInput ADDNAME;
        Crestron.Logos.SplusObjects.DigitalInput REMOVENAME;
        Crestron.Logos.SplusObjects.DigitalInput REFRESHLIST;
        Crestron.Logos.SplusObjects.DigitalInput FETCHNAME;
        Crestron.Logos.SplusObjects.StringInput SEARCHNAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput ADDNAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput ADDDESCRIPTION__DOLLAR__;
        Crestron.Logos.SplusObjects.StringInput ADDCOMMAND__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput BUSY;
        Crestron.Logos.SplusObjects.AnalogOutput LISTLENGHT;
        Crestron.Logos.SplusObjects.StringOutput NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput DESCRIPTION__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput COMMAND__DOLLAR__;
        StringParameter FILEPATH__DOLLAR__;
        jsFetch.jsonReadWrite JSON;
        ushort ROOMLISTLENGHTVAR = 0;
        private void SHOWFECHEDROOM (  SplusExecutionContext __context__, CrestronString NAME , CrestronString DESCRIPTION , CrestronString COMMAND ) 
            { 
            
            __context__.SourceCodeLine = 39;
            NAME__DOLLAR__  .UpdateValue ( NAME  ) ; 
            __context__.SourceCodeLine = 40;
            DESCRIPTION__DOLLAR__  .UpdateValue ( DESCRIPTION  ) ; 
            __context__.SourceCodeLine = 41;
            COMMAND__DOLLAR__  .UpdateValue ( COMMAND  ) ; 
            
            }
            
        private void GETROOMCOUNT (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 46;
            BUSY  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 47;
            ROOMLISTLENGHTVAR = (ushort) ( JSON.GetNumberOfNames() ) ; 
            __context__.SourceCodeLine = 48;
            LISTLENGHT  .Value = (ushort) ( ROOMLISTLENGHTVAR ) ; 
            __context__.SourceCodeLine = 49;
            BUSY  .Value = (ushort) ( 0 ) ; 
            
            }
            
        object ADDNAME_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 60;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ADDNAME__DOLLAR__ != "") ) && Functions.TestForTrue ( Functions.BoolToInt (ADDDESCRIPTION__DOLLAR__ != "") )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (ADDCOMMAND__DOLLAR__ != "") )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 62;
                    JSON . AddName ( ADDNAME__DOLLAR__ .ToString(), ADDDESCRIPTION__DOLLAR__ .ToString(), ADDCOMMAND__DOLLAR__ .ToString()) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 65;
                    Trace( "Adding Room failed") ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ADDNAME_OnRelease_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 70;
            GETROOMCOUNT (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object REMOVENAME_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 75;
        JSON . RemoveName ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REMOVENAME_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 80;
        GETROOMCOUNT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REFRESHLIST_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 85;
        GETROOMCOUNT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INITILIZEFILESYSTEM_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 90;
        JSON . Initialize ( FILEPATH__DOLLAR__  .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FETCHNAME_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 95;
        JSON . fetchName ( SEARCHNAME__DOLLAR__ .ToString()) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void SIMPLPLUSEVENTHANDLER ( object __sender__ /*jsFetch.jsonReadWrite SENDER */, jsFetch.itemValue E ) 
    { 
    jsonReadWrite  SENDER  = (jsonReadWrite )__sender__;
    try
    {
        SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
        
        __context__.SourceCodeLine = 100;
        SHOWFECHEDROOM (  __context__ , E.Name, E.Description, E.Command) ; 
        
        
    }
    finally { ObjectFinallyHandler(); }
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 107;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 110;
        // RegisterEvent( JSON , RETURNITEMVALUE , SIMPLPLUSEVENTHANDLER ) 
        try { g_criticalSection.Enter(); JSON .returnItemValue  += SIMPLPLUSEVENTHANDLER; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 111;
        ROOMLISTLENGHTVAR = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 112;
        JSON . Initialize ( FILEPATH__DOLLAR__  .ToString()) ; 
        __context__.SourceCodeLine = 113;
        GETROOMCOUNT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    
    INITILIZEFILESYSTEM = new Crestron.Logos.SplusObjects.DigitalInput( INITILIZEFILESYSTEM__DigitalInput__, this );
    m_DigitalInputList.Add( INITILIZEFILESYSTEM__DigitalInput__, INITILIZEFILESYSTEM );
    
    ADDNAME = new Crestron.Logos.SplusObjects.DigitalInput( ADDNAME__DigitalInput__, this );
    m_DigitalInputList.Add( ADDNAME__DigitalInput__, ADDNAME );
    
    REMOVENAME = new Crestron.Logos.SplusObjects.DigitalInput( REMOVENAME__DigitalInput__, this );
    m_DigitalInputList.Add( REMOVENAME__DigitalInput__, REMOVENAME );
    
    REFRESHLIST = new Crestron.Logos.SplusObjects.DigitalInput( REFRESHLIST__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESHLIST__DigitalInput__, REFRESHLIST );
    
    FETCHNAME = new Crestron.Logos.SplusObjects.DigitalInput( FETCHNAME__DigitalInput__, this );
    m_DigitalInputList.Add( FETCHNAME__DigitalInput__, FETCHNAME );
    
    BUSY = new Crestron.Logos.SplusObjects.DigitalOutput( BUSY__DigitalOutput__, this );
    m_DigitalOutputList.Add( BUSY__DigitalOutput__, BUSY );
    
    LISTLENGHT = new Crestron.Logos.SplusObjects.AnalogOutput( LISTLENGHT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( LISTLENGHT__AnalogSerialOutput__, LISTLENGHT );
    
    SEARCHNAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( SEARCHNAME__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( SEARCHNAME__DOLLAR____AnalogSerialInput__, SEARCHNAME__DOLLAR__ );
    
    ADDNAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ADDNAME__DOLLAR____AnalogSerialInput__, 50, this );
    m_StringInputList.Add( ADDNAME__DOLLAR____AnalogSerialInput__, ADDNAME__DOLLAR__ );
    
    ADDDESCRIPTION__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ADDDESCRIPTION__DOLLAR____AnalogSerialInput__, 254, this );
    m_StringInputList.Add( ADDDESCRIPTION__DOLLAR____AnalogSerialInput__, ADDDESCRIPTION__DOLLAR__ );
    
    ADDCOMMAND__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( ADDCOMMAND__DOLLAR____AnalogSerialInput__, 150, this );
    m_StringInputList.Add( ADDCOMMAND__DOLLAR____AnalogSerialInput__, ADDCOMMAND__DOLLAR__ );
    
    NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( NAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( NAME__DOLLAR____AnalogSerialOutput__, NAME__DOLLAR__ );
    
    DESCRIPTION__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DESCRIPTION__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DESCRIPTION__DOLLAR____AnalogSerialOutput__, DESCRIPTION__DOLLAR__ );
    
    COMMAND__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( COMMAND__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( COMMAND__DOLLAR____AnalogSerialOutput__, COMMAND__DOLLAR__ );
    
    FILEPATH__DOLLAR__ = new StringParameter( FILEPATH__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEPATH__DOLLAR____Parameter__, FILEPATH__DOLLAR__ );
    
    
    ADDNAME.OnDigitalPush.Add( new InputChangeHandlerWrapper( ADDNAME_OnPush_0, false ) );
    ADDNAME.OnDigitalRelease.Add( new InputChangeHandlerWrapper( ADDNAME_OnRelease_1, false ) );
    REMOVENAME.OnDigitalPush.Add( new InputChangeHandlerWrapper( REMOVENAME_OnPush_2, false ) );
    REMOVENAME.OnDigitalRelease.Add( new InputChangeHandlerWrapper( REMOVENAME_OnRelease_3, false ) );
    REFRESHLIST.OnDigitalPush.Add( new InputChangeHandlerWrapper( REFRESHLIST_OnPush_4, false ) );
    INITILIZEFILESYSTEM.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITILIZEFILESYSTEM_OnPush_5, false ) );
    FETCHNAME.OnDigitalPush.Add( new InputChangeHandlerWrapper( FETCHNAME_OnPush_6, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    JSON  = new jsFetch.jsonReadWrite();
    
    
}

public UserModuleClass_JSONFETCH_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INITILIZEFILESYSTEM__DigitalInput__ = 0;
const uint ADDNAME__DigitalInput__ = 1;
const uint REMOVENAME__DigitalInput__ = 2;
const uint REFRESHLIST__DigitalInput__ = 3;
const uint FETCHNAME__DigitalInput__ = 4;
const uint SEARCHNAME__DOLLAR____AnalogSerialInput__ = 0;
const uint ADDNAME__DOLLAR____AnalogSerialInput__ = 1;
const uint ADDDESCRIPTION__DOLLAR____AnalogSerialInput__ = 2;
const uint ADDCOMMAND__DOLLAR____AnalogSerialInput__ = 3;
const uint BUSY__DigitalOutput__ = 0;
const uint LISTLENGHT__AnalogSerialOutput__ = 0;
const uint NAME__DOLLAR____AnalogSerialOutput__ = 1;
const uint DESCRIPTION__DOLLAR____AnalogSerialOutput__ = 2;
const uint COMMAND__DOLLAR____AnalogSerialOutput__ = 3;
const uint FILEPATH__DOLLAR____Parameter__ = 10;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
