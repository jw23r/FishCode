
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;



/// <summary>
/// Monobehaviour singleton that will auto-generate an instance if one does not exist.
/// </summary>
public class Fishing : MonoBehaviour
{
    #region Properties
    /// <summary>
    /// Public singleton reference that can be accessed externally.
    /// </summary>
    static public Fishing Instance
    {
        get
        {
            // If we don't have a singleton instance, then automatically create one now:
            if (_instance == null) _instance = new GameObject("Monohehaviour Singleton (Auto Generating)").AddComponent<Fishing>();
            return _instance;
        }
    }

    /// <summary>
    /// Static private reference to our singleton instance.
    /// </summary>
    static private Fishing _instance = null;
    #endregion Properties (end)

    #region Initialization	
    private void Awake()
    {
        // Make sure we will only ever have one of these objects:
        if (_instance == null) _instance = this;
        else Destroy(this);
    }
    #endregion Initialization (end)

    public void LogSomeStuff()
    {
        Debug.Log("MonohehaviourSingletonAutoGenerating is logging some stuff!");
    }

    #region On Destroy
    private void OnDestroy()
    {
        // If we were the singleton, then clear the reference as we are being destroyed:
        if (_instance == this) _instance = null;
    }
    #endregion On Destroy (end)



    public FishDataCollection fish;
    List<FishDataObject> catchable = new List<FishDataObject>();
    string fishDataCollectionAttraction;

    string fishDataCollectionTimeOfDay;
    string fishDataCollectionToolRequiredy;
    string fishDataCollectionEnticeMethod;
    string fishDataCollectionRetrievalMethod;
    string fishDataCollectionCastingRange;









    //curreent fishing methdos
    string currentFishAttraction;
    string currentFishRetrivalMethdod;
    string currentFishCastingRange;
    string currentFishTimeOfDay;
    static public string currentFishBodyOfWaterType = "nothing";
    string currentFishToolRequired;
    string currentFishEnticeMethdod;



    //dropdown menus
    public Dropdown attractantOptions;
    public Dropdown RetrivalMethodOptions;
    public Dropdown CastingRangeOptions;
    public Dropdown TimeOfDayOptions;
    public Dropdown BodyOfWaterTypeOptions;
    public Dropdown toolRequiredOptions;
    public Dropdown enticeMethdodOptions;

    public BodyOfWaterType water;

    int fishCaught;
    /*
    enum currentAttractant
    { Lure, Living }
    enum currentRetrivalMethdod
    { Instant, Constant, On, Off }
    enum currentCastingRange
    { Close, Far }
    enum currentTimeOfDay
    { Morning, Day, Evening, Night }
    enum currentToolRequiredOptions
    { Rod, Spear }
    enum currentBodyOfWaterType
    { Ocean, Lake, Pond, Stream }
    enum currententiceMethdod
    {
        Rhythmic, Random, Predictive
    }*/
    // Start is called before the first frame update
    void Start()
    {

        // print(catchable[0]);
        DropDownOptions();

    }


    // Update is called once per frame
    void Update()
    {
        //print(fish.FishDataObjects[0].BodyOfWaterType[BodyOfWaterTypeOptions.value].instanceOfEnum);
        //   print((BodyOfWaterType.bodyOfWaterType)BodyOfWaterTypeOptions.value);

        //print(fish.FishDataObjects[0].BodyOfWaterType[0].instanceOfEnum);
        //  print(attractantOptions.value);



        //print(currentFishAttraction);

        //  print((currentAttractant)attractantOptions.value);

        // print((currentAttractant)attractantOptions.value);

        // SetCurrentFishingMethdod();
    }

    public void CastAndFish()
    {
        if (currentFishBodyOfWaterType == "nothing")
        {
           // print("cant fish here");
            return;
        }
        for (int i = 0; i < fish.FishDataObjects.Count; i++)
        {
            catchable.Add(fish.FishDataObjects[i]);

        }

        for (int j = catchable.Count - 1; j >= 0; j--)
        {
            string waterType = catchable[j].BodyOfWaterType[0].instanceOfEnum.ToString();
            //print(j);
           // print(catchable.Count);
            if (waterType != currentFishBodyOfWaterType &&
                catchable[j].BodyOfWaterType[0].instanceOfEnum != BodyOfWaterType.bodyOfWaterType.Any &&
                catchable[j].BodyOfWaterType[0].instanceOfEnum != BodyOfWaterType.bodyOfWaterType.None)
            {
                //   print("removing1");
                catchable.RemoveAt(j);
                continue;
            }

            if (catchable[j].Attractant[0].instanceOfEnum != (Attractant.attractant)attractantOptions.value &&
                catchable[j].Attractant[0].instanceOfEnum != Attractant.attractant.Any &&
                catchable[j].Attractant[0].instanceOfEnum != Attractant.attractant.None)
            {
                //  print("removing2");

                catchable.RemoveAt(j);
                continue;

            }
            if (catchable[j].CastingRange[0].instanceOfEnum != (CastingRange.castingRange)CastingRangeOptions.value)
            {
                //print("removing3");

                catchable.RemoveAt(j);
                continue;

            }
            if (catchable[j].EnticeMethod[0].instanceOfEnum != (EnticeMethod.enticeMethod)enticeMethdodOptions.value &&
             catchable[j].EnticeMethod[0].instanceOfEnum != EnticeMethod.enticeMethod.Any &&
             catchable[j].EnticeMethod[0].instanceOfEnum != EnticeMethod.enticeMethod.None)
            {
                //print("removing4");

                catchable.RemoveAt(j);
                continue;

            }
            if (catchable[j].RetrievalMethod[0].instanceOfEnum != (RetrievalMethod.retrievalMethod)RetrivalMethodOptions.value &&
             catchable[j].RetrievalMethod[0].instanceOfEnum != RetrievalMethod.retrievalMethod.Off &&
             catchable[j].RetrievalMethod[0].instanceOfEnum != RetrievalMethod.retrievalMethod.On)
            {
                //print("removing5");

                catchable.RemoveAt(j);
                continue;

            }
            if (catchable[j].TimeOfDay[0].instanceOfEnum != (TimeOfDay.timeOfDay)TimeOfDayOptions.value &&
        catchable[j].TimeOfDay[0].instanceOfEnum != TimeOfDay.timeOfDay.Any)

            {
                //   print("removing6");

                catchable.RemoveAt(j);
                continue;

            }
            if (catchable[j].ToolRequired[0].instanceOfEnum != (ToolRequired.toolRequired)toolRequiredOptions.value &&
              catchable[j].ToolRequired[0].instanceOfEnum != ToolRequired.toolRequired.Any &&
              catchable[j].ToolRequired[0].instanceOfEnum != ToolRequired.toolRequired.None)
            {
                // print("removing7");

                catchable.RemoveAt(j);
                continue;

            }
        }
        if (catchable.Count > 0)
        {
            int i = Random.Range(0, catchable.Count);
            print("You caught A" + catchable[i].FishNameTextField);
            catchable.Clear();
        }



        /*
        for (int i = 0; i < fish.FishDataObjects.Count; i++)
        {
            //  print(fish.FishDataObjects.Count);
           // print(i);
            fishDataCollectionAttraction = fish.FishDataObjects[i].Attractant[0].instanceOfEnum.ToString();
            fishDataCollectionBodyOfWaterType = fish.FishDataObjects[i].BodyOfWaterType[0].instanceOfEnum.ToString();
            fishDataCollectionTimeOfDay = fish.FishDataObjects[i].TimeOfDay[0].instanceOfEnum.ToString();
            fishDataCollectionToolRequiredy = fish.FishDataObjects[i].ToolRequired[0].instanceOfEnum.ToString();
            fishDataCollectionEnticeMethod = fish.FishDataObjects[i].EnticeMethod[0].instanceOfEnum.ToString();
            fishDataCollectionRetrievalMethod = fish.FishDataObjects[i].RetrievalMethod[0].instanceOfEnum.ToString();
            fishDataCollectionCastingRange = fish.FishDataObjects[i].CastingRange[0].instanceOfEnum.ToString();
            if (currentFishBodyOfWaterType == "Ocean" || currentFishBodyOfWaterType == "Lake" || currentFishBodyOfWaterType == "Pond" || currentFishBodyOfWaterType == "Stream")
            {
              //  print("1");

                if (fishDataCollectionBodyOfWaterType == currentFishBodyOfWaterType || fishDataCollectionBodyOfWaterType == "None" || fishDataCollectionBodyOfWaterType == "Any")
                {
                   // print("2");

                    if (fishDataCollectionAttraction == currentFishAttraction || fishDataCollectionAttraction == "Any" || fishDataCollectionAttraction == "None")
                    {
                       // print("3");

                        if (fishDataCollectionTimeOfDay == currentFishTimeOfDay || fishDataCollectionTimeOfDay == "Any" || fishDataCollectionTimeOfDay == "None")
                        {
                           // print("4");

                            if (fishDataCollectionToolRequiredy == currentFishToolRequired || fishDataCollectionToolRequiredy == "Any" || fishDataCollectionToolRequiredy == "None")
                            {
                            //    print("5");

                                if (fishDataCollectionEnticeMethod == currentFishEnticeMethdod || fishDataCollectionEnticeMethod == "Any" || fishDataCollectionEnticeMethod == "None")
                                {
                                  //  print("6");

                                    if (fishDataCollectionRetrievalMethod == currentFishRetrivalMethdod || fishDataCollectionRetrievalMethod == "Any" || fishDataCollectionRetrievalMethod == "None")
                                    {
                                      //  print("7");

                                        if (fishDataCollectionCastingRange == currentFishCastingRange || fishDataCollectionCastingRange == "Any" || fishDataCollectionCastingRange == "None")
                                        {
                                        //    print("8");
                                            catchable.Add(fish.FishDataObjects[i]);
                                            //  print(catchable[0].FishNameTextField);
                                           // print(i);
                                            if (i >= fish.FishDataObjects.Count - 1)
                                            {
                                                fishCaught = Random.Range(0, i + 1);
                                                print(catchable[fishCaught].FishNameTextField);
                                                catchable.Clear();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

        }*/
    }

    private void SetCurrentFishingMethdod()
    {
        /* if (currentAttractant.Lure == (currentAttractant)attractantOptions.value)
         {
             currentFishAttraction = currentAttractant.Lure.ToString();
         }
         if (currentAttractant.Living == (currentAttractant)attractantOptions.value)
         {
             currentFishAttraction = currentAttractant.Living.ToString();
         }
         //sets retrival methdod
         if (currentRetrivalMethdod.Constant == (currentRetrivalMethdod)RetrivalMethodOptions.value)
         {


             currentFishRetrivalMethdod = currentRetrivalMethdod.Constant.ToString();
         }
         if (currentRetrivalMethdod.Instant == (currentRetrivalMethdod)RetrivalMethodOptions.value)
         {


             currentFishRetrivalMethdod = currentRetrivalMethdod.Instant.ToString();
         }
         if (currentRetrivalMethdod.Off == (currentRetrivalMethdod)RetrivalMethodOptions.value)
         {


             currentFishRetrivalMethdod = currentRetrivalMethdod.Off.ToString();
         }
         if (currentRetrivalMethdod.On == (currentRetrivalMethdod)RetrivalMethodOptions.value)
         {


             currentFishRetrivalMethdod = currentRetrivalMethdod.On.ToString();
         }
         //sets how far to cast
         if (currentCastingRange.Close == (currentCastingRange)CastingRangeOptions.value)
         {


             currentFishCastingRange = currentCastingRange.Close.ToString();
         }
         if (currentCastingRange.Far == (currentCastingRange)CastingRangeOptions.value)
         {


             currentFishCastingRange = currentCastingRange.Far.ToString();
         }
         /// sets string for time of day
         if (currentTimeOfDay.Day == (currentTimeOfDay)TimeOfDayOptions.value)
         {


             currentFishTimeOfDay = currentTimeOfDay.Day.ToString();
         }
         if (currentTimeOfDay.Evening == (currentTimeOfDay)TimeOfDayOptions.value)
         {


             currentFishTimeOfDay = currentTimeOfDay.Evening.ToString();
         }
         if (currentTimeOfDay.Morning == (currentTimeOfDay)TimeOfDayOptions.value)
         {


             currentFishTimeOfDay = currentTimeOfDay.Morning.ToString();
         }

         if (currentTimeOfDay.Night == (currentTimeOfDay)TimeOfDayOptions.value)
         {


             currentFishTimeOfDay = currentTimeOfDay.Night.ToString();
         }
         //sets body of water type
         if (currentBodyOfWaterType.Ocean == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
         {


             currentFishBodyOfWaterType = currentBodyOfWaterType.Ocean.ToString();
         }
         if (currentBodyOfWaterType.Lake == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
         {


             currentFishBodyOfWaterType = currentBodyOfWaterType.Lake.ToString();
         }
         if (currentBodyOfWaterType.Pond == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
         {


             currentFishBodyOfWaterType = currentBodyOfWaterType.Pond.ToString();
         }
         if (currentBodyOfWaterType.Stream == (currentBodyOfWaterType)BodyOfWaterTypeOptions.value)
         {


             currentFishBodyOfWaterType = currentBodyOfWaterType.Stream.ToString();
         }
         //sets string for tool
         if (currentToolRequiredOptions.Rod == (currentToolRequiredOptions)toolRequiredOptions.value)
         {


             currentFishToolRequired = currentToolRequiredOptions.Rod.ToString();
         }
         if (currentToolRequiredOptions.Spear == (currentToolRequiredOptions)toolRequiredOptions.value)
         {


             currentFishToolRequired = currentToolRequiredOptions.Spear.ToString();
         }
         // sets string for entice
         if (currententiceMethdod.Predictive == (currententiceMethdod)enticeMethdodOptions.value)
         {


             currentFishEnticeMethdod = currententiceMethdod.Predictive.ToString();
         }


         if (currententiceMethdod.Random == (currententiceMethdod)enticeMethdodOptions.value)
         {


             currentFishEnticeMethdod = currententiceMethdod.Random.ToString();
         }
         if (currententiceMethdod.Rhythmic == (currententiceMethdod)enticeMethdodOptions.value)
         {


             currentFishEnticeMethdod = currententiceMethdod.Rhythmic.ToString();
         }
         */


    }

    void DropDownOptions()
    {  // sets attraction dropdown
        string[] enumAttractant = Enum.GetNames(typeof(Attractant.attractant));
        List<string> currentAttractantDDOptions = new List<string>(enumAttractant);
        attractantOptions.AddOptions(currentAttractantDDOptions);
        // sets retrival dropdown

        string[] enumRetrivalMethodOptions = Enum.GetNames(typeof(RetrievalMethod.retrievalMethod));
        List<string> currentRetrivalMethdodDDOptions = new List<string>(enumRetrivalMethodOptions);
        RetrivalMethodOptions.AddOptions(currentRetrivalMethdodDDOptions);

        // sets casting range methdod
        string[] enumCastingRangeOptions = Enum.GetNames(typeof(CastingRange.castingRange));
        List<string> enumCastingRangeDDOptions = new List<string>(enumCastingRangeOptions);
        CastingRangeOptions.AddOptions(enumCastingRangeDDOptions);

        //sets time of day
        string[] enumCurrentTimeOfDay = Enum.GetNames(typeof(TimeOfDay.timeOfDay));
        List<string> enumCurrentTimeOfDayDDOptions = new List<string>(enumCurrentTimeOfDay);
        TimeOfDayOptions.AddOptions(enumCurrentTimeOfDayDDOptions);

        //sets type of water
        string[] enumcurrentBodyOfWaterType = Enum.GetNames(typeof(BodyOfWaterType.bodyOfWaterType));
        List<string> enumcurrentBodyOfWaterTypeDDOptions = new List<string>(enumcurrentBodyOfWaterType);
        BodyOfWaterTypeOptions.AddOptions(enumcurrentBodyOfWaterTypeDDOptions);

        //sets entice required
        string[] enumcurrententiceMethdod = Enum.GetNames(typeof(EnticeMethod.enticeMethod));
        List<string> enumenumcurrententiceMethdodDDOptions = new List<string>(enumcurrententiceMethdod);
        enticeMethdodOptions.AddOptions(enumenumcurrententiceMethdodDDOptions);

        //setsentice methdod
        string[] enumcurrentToolRequiredOptions = Enum.GetNames(typeof(ToolRequired.toolRequired));
        List<string> enumcurrentToolRequireddDDOptions = new List<string>(enumcurrentToolRequiredOptions);
        toolRequiredOptions.AddOptions(enumcurrentToolRequireddDDOptions);
        /*   // sets attraction dropdown
           string[] enumAttractant = Enum.GetNames(typeof(currentAttractant));
           List<string> currentAttractantDDOptions = new List<string>(enumAttractant);
           attractantOptions.AddOptions(currentAttractantDDOptions);
           // sets retrival dropdown

           string[] enumRetrivalMethodOptions = Enum.GetNames(typeof(currentRetrivalMethdod));
           List<string> currentRetrivalMethdodDDOptions = new List<string>(enumRetrivalMethodOptions);
           RetrivalMethodOptions.AddOptions(currentRetrivalMethdodDDOptions);

           // sets casting range methdod
           string[] enumCastingRangeOptions = Enum.GetNames(typeof(currentCastingRange));
           List<string> enumCastingRangeDDOptions = new List<string>(enumCastingRangeOptions);
           CastingRangeOptions.AddOptions(enumCastingRangeDDOptions);

           //sets time of day
           string[] enumCurrentTimeOfDay = Enum.GetNames(typeof(currentTimeOfDay));
           List<string> enumCurrentTimeOfDayDDOptions = new List<string>(enumCurrentTimeOfDay);
           TimeOfDayOptions.AddOptions(enumCurrentTimeOfDayDDOptions);

           //sets type of water
           string[] enumcurrentBodyOfWaterType = Enum.GetNames(typeof(currentBodyOfWaterType));
           List<string> enumcurrentBodyOfWaterTypeDDOptions = new List<string>(enumcurrentBodyOfWaterType);
           BodyOfWaterTypeOptions.AddOptions(enumcurrentBodyOfWaterTypeDDOptions);

           //sets entice required
           string[] enumcurrententiceMethdod = Enum.GetNames(typeof(currententiceMethdod));
           List<string> enumenumcurrententiceMethdodDDOptions = new List<string>(enumcurrententiceMethdod);
           enticeMethdodOptions.AddOptions(enumenumcurrententiceMethdodDDOptions);

           //setsentice methdod
           string[] enumcurrentToolRequiredOptions = Enum.GetNames(typeof(currentToolRequiredOptions));
           List<string> enumcurrentToolRequireddDDOptions = new List<string>(enumcurrentToolRequiredOptions);
           toolRequiredOptions.AddOptions(enumcurrentToolRequireddDDOptions);
           */
    }
}
