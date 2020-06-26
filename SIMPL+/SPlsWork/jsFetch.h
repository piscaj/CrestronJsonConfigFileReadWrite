namespace jsFetch;
        // class declarations
         class Key;
         class jsonObject;
         class itemValue;
         class jsonReadWrite;
     class Key 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Number;
        STRING Name[];
        STRING Description[];
        STRING Command[];
        STRING Test[];
    };

     class jsonObject 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class itemValue 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER Number;
        STRING Name[];
        STRING Description[];
        STRING Command[];
    };

     class jsonReadWrite 
    {
        // class delegates

        // class events
        EventHandler returnItemValue ( jsonReadWrite sender, itemValue e );

        // class functions
        FUNCTION Initialize ( STRING fileLocation );
        FUNCTION DeserializeJson ();
        INTEGER_FUNCTION GetNumberOfNames ();
        FUNCTION fetchName ( STRING searchName );
        FUNCTION AddName ( STRING _Name , STRING _Command , STRING _Description );
        FUNCTION RemoveName ();
        FUNCTION UpdateJSON ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

