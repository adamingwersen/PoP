/// <summary> ø6.1 </summary>
type weekday =
    Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let dayToNumber =
  match weekday with
  | Monday -> 1
  | Tuesday -> 2
  | Wednesday -> 3
  | Thursday -> 4
  | Friday -> 5
  | Saturday -> 6
  | Sunday -> 7

let numberToDay =
  match n with
  | 1 -> Monday
  | 2 -> Tuesday
  | 3 -> Wednesday
  | 4 -> Thursday
  | 5 -> Friday
  | 6 -> Saturday
  | 7 -> Sunday

/// Ø6.2
let nextDay =
  match weekday with
  | Monday -> Tuesday
  | Tuesday -> Wednesday
  | Wednesday -> Thursday
  | Thursday -> Friday
  | Friday -> Saturday
  | Saturday -> Sunday
  | Sunday -> Monday

