module Types

type RemoteData<'data, 'error> =
    | NotAsked
    | Loading
    | Failure of 'error
    | Success of 'data

type AgeGroup =
    { AgeFrom : int option
      AgeTo : int option
      TestedPositiveMale : int option
      TestedPositiveFemale : int option
      TestedPositiveAll : int option }

type AgeGroups =
    { Below16 : AgeGroup
      From16to29 : AgeGroup
      From30to49 : AgeGroup
      From50to59 : AgeGroup
      Above60 : AgeGroup }

type StatsDataPoint =
    { Date : System.DateTime
      Tests : int option
      TotalTests : int option
      PositiveTests : int option
      TotalPositiveTests : int option
      Hospitalized : int option
      HospitalizedIcu : int option
      Deaths : int option
      TotalDeaths : int option
      AgeGroups : AgeGroups }

type StatsData = StatsDataPoint list

type Metric =
    { Color : string
      Visible : bool
      Label : string }

type Metrics =
    { Tests : Metric
      TotalTests : Metric
      PositiveTests : Metric
      TotalPositiveTests : Metric
      Hospitalized : Metric
      HospitalizedIcu : Metric
      Deaths : Metric
      TotalDeaths : Metric }

type MetricMsg =
    | Tests
    | TotalTests
    | PositiveTests
    | TotalPositiveTests
    | Hospitalized
    | HospitalizedIcu
    | Deaths
    | TotalDeaths

type State =
    { StatsData : RemoteData<StatsData, string>
      Metrics : Metrics }

type Msg =
    | StatsDataLoaded of RemoteData<StatsData, string>
    | ToggleMetricVisible of MetricMsg
