Projecto 5 Clara

1. Users
	* Roles (users) [UserRoles] [V]
	* Favorite recepies [] [X]
	* State [UserState] [V]

1. Recepies
	* State [RecepieStatus] [V]
	* Description [String] [V]
	* Ingredients (N) [List[Ingredients]] [V]
	* Categories (N) [Set[String]] [V]
	* Dificulty level [int] [V]
	* Duration (minutes) [int] [V]
	* Created By (User) [User] [V]
	* Created At (data) [Date] [V]

1. RecepieInfo
	* User [] []
	* Comments (N) [] []
	* Rating [] []
	* Recepie [] []
	* Created Date [] []

1. Ingredients
	* quantity [Double] [V]
	* measure [String] [V]
	* name [String] [V]
	
	
	======= PS ======
	Enum
	Pros 
	- auto validated
	- display the valid options
	Cons
	- create an entry in the enum for each difficulty [X]
		
	Integer
	Pros 
    - simple
    Cons
    - need to validate the range
	
	String
	Pros 
	- simple
	Cons
	- how to validate
	- hot to list all the dificulties
	
	Collection 
        - Set (collection of non repeated elements)
        - List (collection of elements can be repeated)
        - Array (collection of fixed sized elements)
        
        ---- Clara v2 ----
        Queue
        Stack
        Map
        Tree 
	...
	
	String => "2020-15-10 12:10:00T" UTC/GSM ....
    Date => ...
    Int => 20201210...
    LONG => Milliseconds since epox
    
    Created at => String
    Pros:
    * Simple
    Cons:
    * hard to validate 
    * hard to filter ranges
    
    Created at => Date
    Pros:
    * Simple
    * Safe
    * Auto validated
    * can know day of the week
    * ...
    Cons:
    * Need to define Timezones
    * harder to filter ranges
    
    
    Created at => Milliseconds
    Pros:
    * Simple
    * Autovalidated
    * Safe
    * Easy to filter ranges
    Cons:
    * Unreadable 
    * Conversion needed to be human readable
    
    	
    Receita => String user ...
    Pros:
    * Simple
    Cons:
    * Unsafe 
    * Hard to access user
    
    vs
    
    Receita => User user ...
    Pros:
    * Safe
    * Easy to access user
    Cons:
    * More complex
    * Possible more time to obtain
    

	
