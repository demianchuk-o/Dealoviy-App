Ö
ZD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Users\User.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Users 
;  
public 
class 
User 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public 

string 
Username 
{ 
get  
;  !
private" )
set* -
;- .
}/ 0
public 

string 
? 
DisplayName 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
=5 6
null7 ;
;; <
public 

string 
PasswordHash 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public

 

Guid

 
?

 
ContractorProfileId

 $
{

% &
get

' *
;

* +
private

, 3
set

4 7
;

7 8
}

9 :
=

; <
null

= A
;

A B
public 

static 
User 
Create 
( 
string $
username% -
,- .
string/ 5
?5 6
displayName7 B
,B C
stringD J
passwordHashK W
)W X
{ 
return 
new 
User 
( 
username  
,  !
displayName" -
,- .
passwordHash/ ;
); <
;< =
} 
public 

User 
Update 
( 
string 
? 
displayName *
)* +
{ 
DisplayName 
= 
( 
string 
. 
IsNullOrWhiteSpace 0
(0 1
displayName1 <
)< =
)= >
? 
null 
: 
displayName 
; 
return 
this 
; 
} 
private 
User 
( 
string 
username  
,  !
string" (
?( )
displayName* 5
,5 6
string7 =
passwordHash> J
)J K
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
Username 
= 
username 
; 
DisplayName 
= 
( 
string 
. 
IsNullOrWhiteSpace 0
(0 1
displayName1 <
)< =
)= >
? 
null 
: 
displayName 
; 
PasswordHash   
=   
passwordHash   #
;  # $
}!! 
public## 

void## "
SetContractorProfileId## &
(##& '
Guid##' +
contractorProfileId##, ?
)##? @
{$$ 
ContractorProfileId%% 
=%% 
contractorProfileId%% 1
;%%1 2
}&& 
public(( 

string(( 
GetDisplayName((  
(((  !
)((! "
{)) 
return** 
DisplayName** 
??** 
Username** &
;**& '
}++ 
private,, 
User,, 
(,, 
),, 
{,, 
},, 
}-- “
aD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Users\Errors.User.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
static 
partial 
class 
Errors "
{ 
public 

static 
Error 
DuplicateUsername )
=>* ,
Error- 2
.2 3
Conflict3 ;
(; <
code 
: 
$str &
,& '
description		 
:		 
$str		 1
)		1 2
;		2 3
public 

static 
Error 
UserNotFound $
=>% '
Error( -
.- .
NotFound. 6
(6 7
code 
: 
$str 
, 
description 
: 
$str )
)) *
;* +
} Ú
kD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Users\Errors.Authentication.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
static 
partial 
class 
Errors "
{ 
public 

static 
Error 
InvalidCredentials *
=>+ -
Error. 3
.3 4

Validation4 >
(> ?
code 
: 
$str *
,* +
description		 
:		 
$str		 /
)		/ 0
;		0 1
}

 Â
pD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Services\ValueObjects\PriceRange.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Services "
." #
ValueObjects# /
;/ 0
public 
record 

PriceRange 
{ 
public 

int 
Lower 
{ 
get 
; 
init  
;  !
}" #
public		 

int		 
Upper		 
{		 
get		 
;		 
init		  
;		  !
}		" #
public 

static 
ErrorOr 
< 

PriceRange $
>$ %
Create& ,
(, -
int- 0
lower1 6
,6 7
int8 ;
upper< A
)A B
{ 
if 

( 
lower 
< 
$num 
|| 
upper 
<  
$num! "
)" #
{ 	
return 
Errors 
. 
NegativePriceRange ,
;, -
} 	
if 

( 
lower 
> 
upper 
) 
{ 	
return 
Errors 
. +
LowerBoundGreaterThanUpperBound 9
;9 :
} 	
return 
new 

PriceRange 
( 
lower #
,# $
upper% *
)* +
;+ ,
} 
private 

PriceRange 
( 
int 
lower  
,  !
int" %
upper& +
)+ ,
{ 
Lower 
= 
lower 
; 
Upper 
= 
upper 
; 
} 
} Š
sD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Services\ValueObjects\AverageRating.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Services "
." #
ValueObjects# /
;/ 0
public 
class 
AverageRating 
{ 
public 

double 
Value 
{ 
get 
; 
private &
set' *
;* +
}, -
=. /
$num0 1
;1 2
public 

int 
Count 
{ 
get 
; 
private #
set$ '
;' (
}) *
=+ ,
$num- .
;. /
public 

void 
	AddRating 
( 
int 
rating $
)$ %
{		 
Value

 
=

 
(

 
Value

 
*

 
Count

 
+

  
rating

! '
)

' (
/

) *
(

+ ,
Count

, 1
+

2 3
$num

4 5
)

5 6
;

6 7
Count 
++ 
; 
} 
public 

void 
RemoveRating 
( 
int  
rating! '
)' (
{ 
if 

( 
Count 
== 
$num 
) 
{ 	
return 
; 
} 	
Value 
= 
( 
Value 
* 
Count 
-  
rating! '
)' (
/) *
(+ ,
Count, 1
-2 3
$num4 5
)5 6
;6 7
Count 
-- 
; 
} 
} Ô(
`D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Services\Service.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Services "
;" #
public 
class 
Service 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public		 

Guid		 
ContractorId		 
{		 
get		 "
;		" #
private		$ +
set		, /
;		/ 0
}		1 2
public

 

Guid

 
CityId

 
{

 
get

 
;

 
private

 %
set

& )
;

) *
}

+ ,
public 

string 
Name 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 

string 
Description 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 


PriceRange 

PriceRange  
{! "
get# &
;& '
private( /
set0 3
;3 4
}5 6
public 

AverageRating 
AverageRating &
{' (
get) ,
;, -
private. 5
set6 9
;9 :
}; <
== >
new? B
(B C
)C D
;D E
public 

static 
ErrorOr 
< 
Service !
>! "
Create# )
() *
Guid 
contractorId 
, 
Guid 
cityId 
, 
string 
name 
, 
string 
description 
, 
int 
lowerPriceBound 
, 
int 
upperPriceBound 
) 
{ 
var 

priceRange 
= 

PriceRange #
.# $
Create$ *
(* +
lowerPriceBound+ :
,: ;
upperPriceBound< K
)K L
;L M
if 

( 

priceRange 
. 
IsError 
) 
{ 	
return 

priceRange 
. 
Errors $
;$ %
} 	
return 
new 
Service 
( 
contractorId   
,   
cityId!! 
,!! 
name"" 
,"" 
description## 
,## 

priceRange$$ 
.$$ 
Value$$ 
)$$ 
;$$ 
}%% 
public'' 

ErrorOr'' 
<'' 
Service'' 
>'' 
Update'' "
(''" #
Guid(( 
cityId(( 
,(( 
string)) 
name)) 
,)) 
string** 
description** 
,** 
int++ 
lowerPriceBound++ 
,++ 
int,, 
upperPriceBound,, 
),, 
{-- 
var.. 

priceRange.. 
=.. 

PriceRange.. #
...# $
Create..$ *
(..* +
lowerPriceBound..+ :
,..: ;
upperPriceBound..< K
)..K L
;..L M
if00 

(00 

priceRange00 
.00 
IsError00 
)00 
{11 	
return22 

priceRange22 
.22 
Errors22 $
;22$ %
}33 	
CityId55 
=55 
cityId55 
;55 
Name66 
=66 
name66 
;66 
Description77 
=77 
description77 !
;77! "

PriceRange88 
=88 

priceRange88 
.88  
Value88  %
;88% &
return:: 
this:: 
;:: 
};; 
private== 
Service== 
(== 
Guid>> 
contractorId>> 
,>> 
Guid?? 
cityId?? 
,?? 
string@@ 
name@@ 
,@@ 
stringAA 
descriptionAA 
,AA 

PriceRangeBB 

priceRangeBB 
)BB 
{CC 
IdDD 

=DD 
GuidDD 
.DD 
NewGuidDD 
(DD 
)DD 
;DD 
ContractorIdEE 
=EE 
contractorIdEE #
;EE# $
CityIdFF 
=FF 
cityIdFF 
;FF 
NameGG 
=GG 
nameGG 
;GG 
DescriptionHH 
=HH 
descriptionHH !
;HH! "

PriceRangeII 
=II 

priceRangeII 
;II  
}JJ 
privateLL 
ServiceLL 
(LL 
)LL 
{LL 
}LL 
}MM ¢
fD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Requests\RequestStatus.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Requests "
;" #
public 
enum 
RequestStatus 
{ 
Pending 
, 
Declined 
, 
Accepted 
} •
^D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Reviews\Review.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Reviews !
;! "
public 
class 
Review 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public 

Guid 
	ServiceId 
{ 
get 
;  
private! (
set) ,
;, -
}. /
public 

Guid 
UserId 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 

int 
Rating 
{ 
get 
; 
private $
set% (
;( )
}* +
public		 

string		 
Text		 
{		 
get		 
;		 
private		 %
set		& )
;		) *
}		+ ,
public

 

DateTime

 
	CreatedAt

 
{

 
get

  #
;

# $
private

% ,
set

- 0
;

0 1
}

2 3
public 

static 
Review 
Create 
(  
Guid 
	serviceId 
, 
Guid 
userId 
, 
int 
rating 
, 
string 
text 
, 
DateTime 
	createdAt 
) 
{ 
return 
new 
Review 
( 
	serviceId #
,# $
userId% +
,+ ,
rating- 3
,3 4
text5 9
,9 :
	createdAt; D
)D E
;E F
} 
private 
Review 
( 
Guid 
	serviceId 
, 
Guid 
userId 
, 
int 
rating 
, 
string 
text 
, 
DateTime 
	createdAt 
) 
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
	ServiceId 
= 
	serviceId 
; 
UserId 
= 
userId 
; 
Rating   
=   
rating   
;   
Text!! 
=!! 
text!! 
;!! 
	CreatedAt"" 
="" 
	createdAt"" 
;"" 
}## 
private$$ 
Review$$ 
($$ 
)$$ 
{$$ 
}$$ 
}%% þ
gD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Services\Errors.Service.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
static 
partial 
class 
Errors "
{ 
public 

static 
Error 
NegativePriceRange *
=>+ -
Error 
. 

Validation 
( 
$str @
,@ A
$str		 ,
)		, -
;		- .
public 

static 
Error +
LowerBoundGreaterThanUpperBound 7
=>8 :
Error 
. 

Validation 
( 
$str M
,M N
$str <
)< =
;= >
public 

static 
Error 
ServiceNotFound '
=>( *
Error 
. 
NotFound 
( 
$str *
)* +
;+ ,
} ô)
`D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Requests\Request.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Requests "
;" #
public 
class 
Request 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public		 

Guid		 

CustomerId		 
{		 
get		  
;		  !
private		" )
set		* -
;		- .
}		/ 0
public

 

Guid

 
	ServiceId

 
{

 
get

 
;

  
private

! (
set

) ,
;

, -
}

. /
public 

string 
Description 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 

int 
PaymentAmount 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 

DateTime 
RequestDate 
{  !
get" %
;% &
private' .
set/ 2
;2 3
}4 5
public 

RequestStatus 
RequestStatus &
{' (
get) ,
;, -
private. 5
set6 9
;9 :
}; <
public 

ContactInfo 
CustomerContactInfo *
{+ ,
get- 0
;0 1
private2 9
set: =
;= >
}? @
public 

ContactInfo !
ContractorContactInfo ,
{- .
get/ 2
;2 3
private4 ;
set< ?
;? @
}A B
public 

static 
ErrorOr 
< 
Request !
>! "
Create# )
() *
Guid 

customerId 
, 
Guid 
	serviceId 
, 
string 
description 
, 
int 
paymentAmount 
, 
DateTime 
requestDate 
, 
RequestStatus 
requestStatus #
,# $"
ContactInfoCreateModel 
customerContactInfo 2
,2 3
ContactInfo !
contractorContactInfo )
)) *
{ 
var %
customerContactInfoResult %
=& '
ContactInfo( 3
.3 4
Create4 :
(: ;
customerContactInfo; N
)N O
;O P
if 

( %
customerContactInfoResult %
.% &
IsError& -
)- .
{ 	
return %
customerContactInfoResult ,
., -
Errors- 3
;3 4
}   	
return## 
new## 
Request## 
(## 

customerId$$ 
,$$ 
	serviceId%% 
,%% 
description&& 
,&& 
paymentAmount'' 
,'' 
requestDate(( 
,(( 
requestStatus)) 
,)) %
customerContactInfoResult** %
.**% &
Value**& +
,**+ ,!
contractorContactInfo++ !
)++! "
;++" #
},, 
public.. 

void.. 
UpdateRequestStatus.. #
(..# $
RequestStatus..$ 1
requestStatus..2 ?
)..? @
{// 
RequestStatus00 
=00 
requestStatus00 %
;00% &
}11 
private33 
Request33 
(33 
Guid44 

customerId44 
,44 
Guid55 
	serviceId55 
,55 
string66 
description66 
,66 
int77 
paymentAmount77 
,77 
DateTime88 
requestDate88 
,88 
RequestStatus99 
requestStatus99 #
,99# $
ContactInfo:: 
customerContactInfo:: '
,::' (
ContactInfo;; !
contractorContactInfo;; )
);;) *
{<< 
Id== 

=== 
Guid== 
.== 
NewGuid== 
(== 
)== 
;== 

CustomerId>> 
=>> 

customerId>> 
;>>  
	ServiceId?? 
=?? 
	serviceId?? 
;?? 
Description@@ 
=@@ 
description@@ !
;@@! "
PaymentAmountAA 
=AA 
paymentAmountAA %
;AA% &
RequestDateBB 
=BB 
requestDateBB !
;BB! "
RequestStatusCC 
=CC 
requestStatusCC %
;CC% &
CustomerContactInfoDD 
=DD 
customerContactInfoDD 1
;DD1 2!
ContractorContactInfoEE 
=EE !
contractorContactInfoEE  5
;EE5 6
}FF 
privateHH 
RequestHH 
(HH 
)HH 
{HH 
}HH 
}II Ÿ
bD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Orders\OrderStatus.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Orders  
;  !
public 
enum 
OrderStatus 
{ 

NotStarted 
, 

InProgress 
, 
Finished 
} “#
\D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Orders\Order.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Orders  
;  !
public 
class 
Order 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public		 

Guid		 

CustomerId		 
{		 
get		  
;		  !
private		" )
set		* -
;		- .
}		/ 0
public

 

Guid

 
	ServiceId

 
{

 
get

 
;

  
private

! (
set

) ,
;

, -
}

. /
public 

string 
Description 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 

int 
PaymentAmount 
{ 
get "
;" #
private$ +
set, /
;/ 0
}1 2
public 

DateTime 
	OrderDate 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 

OrderStatus 
OrderStatus "
{# $
get% (
;( )
private* 1
set2 5
;5 6
}7 8
public 

ContactInfo 
CustomerContactInfo *
{+ ,
get- 0
;0 1
private2 9
set: =
;= >
}? @
public 

ContactInfo !
ContractorContactInfo ,
{- .
get/ 2
;2 3
private4 ;
set< ?
;? @
}A B
public 

static 
Order 
Create 
( 
Request &
request' .
,. /
DateTime0 8
	orderDate9 B
)B C
{ 
return 
new 
Order 
( 
request 
. 

CustomerId 
, 
request 
. 
	ServiceId 
, 
request 
. 
Description 
,  
request 
. 
PaymentAmount !
,! "
	orderDate 
, 
request 
. 
CustomerContactInfo '
,' (
request 
. !
ContractorContactInfo )
)) *
;* +
} 
public 

void 
UpdateOrderStatus !
(! "
OrderStatus" -
orderStatus. 9
)9 :
{ 
OrderStatus   
=   
orderStatus   !
;  ! "
}!! 
private"" 
Order"" 
("" 
Guid## 

customerId## 
,## 
Guid$$ 
	serviceId$$ 
,$$ 
string%% 
description%% 
,%% 
int&& 
paymentAmount&& 
,&& 
DateTime'' 
	orderDate'' 
,'' 
ContactInfo(( 
customerContactInfo(( '
,((' (
ContactInfo)) !
contractorContactInfo)) )
)))) *
{** 
Id++ 

=++ 
Guid++ 
.++ 
NewGuid++ 
(++ 
)++ 
;++ 

CustomerId,, 
=,, 

customerId,, 
;,,  
	ServiceId-- 
=-- 
	serviceId-- 
;-- 
Description.. 
=.. 
description.. !
;..! "
PaymentAmount// 
=// 
paymentAmount// %
;//% &
	OrderDate00 
=00 
	orderDate00 
;00 
OrderStatus11 
=11 
OrderStatus11 !
.11! "

NotStarted11" ,
;11, -
CustomerContactInfo22 
=22 
customerContactInfo22 1
;221 2!
ContractorContactInfo33 
=33 !
contractorContactInfo33  5
;335 6
}44 
private66 
Order66 
(66 
)66 
{66 
}66 
}77 «
{D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\ContractorProfiles\Errors.ContractorProfile.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
static 
partial 
class 
Errors "
{ 
public 

static 
Error  
UserIsNotAContractor ,
=> 

Error 
. 
Conflict 
( 
$str 1
,1 2
$str3 M
)M N
;N O
public		 

static		 
Error		 %
ContractorProfileNotFound		 1
=>

 

Error

 
.

 
NotFound

 
(

 
$str

 6
,

6 7
$str

8 V
)

V W
;

W X
} ¹-
tD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\ContractorProfiles\ContractorProfile.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
ContractorProfiles ,
;, -
public 
class 
ContractorProfile 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public		 

string		 
AdditionalInfo		  
{		! "
get		# &
;		& '
private		( /
set		0 3
;		3 4
}		5 6
public

 

List

 
<

 
ContactInfo

 
>

 
ContactInfos

 )
{

* +
get

, /
;

/ 0
private

1 8
set

9 <
;

< =
}

> ?
public 

static 
ErrorOr 
< 
ContractorProfile +
>+ ,
Create- 3
(3 4
string 
additionalInfo 
, 
List 
< "
ContactInfoCreateModel #
># $
contactInfos% 1
)1 2
{ 
var 
contactInfoResult 
= )
ValidateAndCreateContactInfos  =
(= >
contactInfos> J
)J K
;K L
if 

( 
contactInfoResult 
. 
IsError %
)% &
{ 	
return 
contactInfoResult $
.$ %
Errors% +
;+ ,
} 	
return 
new 
ContractorProfile $
($ %
additionalInfo% 3
,3 4
contactInfoResult5 F
.F G
ValueG L
)L M
;M N
} 
public 

ErrorOr 
< 
ContractorProfile %
>% &
Update' -
(- .
string 
additionalInfo 
, 
List 
< "
ContactInfoCreateModel #
># $
contactInfos% 1
)1 2
{ 
var 
contactInfoResult 
= )
ValidateAndCreateContactInfos  =
(= >
contactInfos> J
)J K
;K L
if   

(   
contactInfoResult   
.   
IsError   %
)  % &
{!! 	
return"" 
contactInfoResult"" $
.""$ %
Errors""% +
;""+ ,
}## 	
AdditionalInfo%% 
=%% 
additionalInfo%% '
;%%' (
ContactInfos&& 
=&& 
contactInfoResult&& (
.&&( )
Value&&) .
;&&. /
return(( 
this(( 
;(( 
})) 
private++ 
ContractorProfile++ 
(++ 
string,, 
additionalInfo,, 
,,, 
List-- 
<-- 
ContactInfo-- 
>-- 
contactInfos-- &
)--& '
{.. 
Id// 

=// 
Guid// 
.// 
NewGuid// 
(// 
)// 
;// 
AdditionalInfo00 
=00 
additionalInfo00 '
;00' (
ContactInfos11 
=11 
contactInfos11 #
;11# $
}22 
private44 
ContractorProfile44 
(44 
)44 
{44  !
}44! "
private66 
static66 
ErrorOr66 
<66 
List66 
<66  
ContactInfo66  +
>66+ ,
>66, -)
ValidateAndCreateContactInfos66. K
(66K L
List77 
<77 "
ContactInfoCreateModel77 #
>77# $
contactInfos77% 1
)771 2
{88 
if99 

(99 
!99 
contactInfos99 
.99 
Any99 
(99 
)99 
)99  
{:: 	
return;; 
Error;; 
.;; 

Validation;; #
(;;# $
$str;;$ 8
,;;8 9
$str;;: r
);;r s
;;;s t
}<< 	
var>> 
contactInfoModels>> 
=>> 
contactInfos>>  ,
.>>, -
Select>>- 3
(>>3 4
cim?? 
=>?? 
ContactInfo?? 
.?? 
Create?? %
(??% &
cim??& )
)??) *
)??* +
;??+ ,
varAA 
contactInfoErrorsAA 
=AA 
contactInfoModelsAA  1
.BB 
WhereBB 
(BB 
cimBB 
=>BB 
cimBB 
.BB 
IsErrorBB %
)BB% &
;BB& '
ifDD 

(DD 
contactInfoErrorsDD 
.DD 
AnyDD !
(DD! "
)DD" #
)DD# $
{EE 	
returnFF 
contactInfoErrorsFF $
.FF$ %
SelectFF% +
(FF+ ,
cieFF, /
=>FF0 2
cieFF3 6
.FF6 7

FirstErrorFF7 A
)FFA B
.GG 
ToListGG 
(GG 
)GG 
;GG 
}HH 	
varJJ 
contactInfoValuesJJ 
=JJ 
contactInfoModelsJJ  1
.KK 
SelectKK 
(KK 
cimKK 
=>KK 
cimKK 
.KK 
ValueKK $
)KK$ %
.LL 
ToListLL 
(LL 
)LL 
;LL 
returnNN 
contactInfoValuesNN  
;NN  !
}OO 
}PP ¯

fD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\Location\Region.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Location! )
;) *
public 
class 
Region 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public 

string 
Name 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 

static 
Region 
Create 
(  
string  &
name' +
)+ ,
{		 
return

 
new

 
Region

 
(

 
name

 
)

 
;

  
} 
private 
Region 
( 
string 
name 
) 
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
Name 
= 
name 
; 
} 
} ”
kD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\Location\Errors.City.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
partial 
class 
Errors 
{ 
public 

static 
Error 
CityNotFound $
=>% '
Error 
. 
NotFound 
( 
$str &
,& '
$"( *
$str* <
"< =
)= >
;> ?
}		 ±
dD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\Location\City.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Location! )
;) *
public 
class 
City 
{ 
public 

Guid 
Id 
{ 
get 
; 
private !
set" %
;% &
}' (
public 

string 
Name 
{ 
get 
; 
private %
set& )
;) *
}+ ,
public 

Guid 
RegionId 
{ 
get 
; 
private  '
set( +
;+ ,
}- .
public		 

static		 
City		 
Create		 
(		 
string		 $
name		% )
,		) *
Guid		+ /
regionId		0 8
)		8 9
{

 
return 
new 
City 
( 
name 
, 
regionId &
)& '
;' (
} 
private 
City 
( 
string 
name 
, 
Guid "
regionId# +
)+ ,
{ 
Id 

= 
Guid 
. 
NewGuid 
( 
) 
; 
Name 
= 
name 
; 
RegionId 
= 
regionId 
; 
} 
} •
uD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\ContactInfo\Errors.ContactInfo.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
Errors! '
;' (
public 
partial 
class 
Errors 
{ 
public 

static 
Error "
InvalidContactInfoType .
(. /
string/ 5
type6 :
): ;
=>		 

Error		 
.		 

Validation		 
(		 
$str		 A
,		A B
$"

 
$str

 !
{

! "
type

" &
}

& '
$str

' 3
"

3 4
)

4 5
;

5 6
public 

static 
Error 
InvalidPhoneNumber *
(* +
ContactInfoType+ :
type; ?
)? @
=> 

Error 
. 

Validation 
( 
$str M
,M N
$" 

$str
  
{  !
type! %
}% &
$str& B
"B C
)C D
;D E
public 

static 
Error 
InvalidUserHandle )
() *
ContactInfoType* 9
type: >
)> ?
=> 

Error 
. 

Validation 
( 
$str L
,L M
$" 
$str )
{) *
type* .
}. /
$str/ J
"J K
)K L
;L M
} ö
rD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\ContactInfo\ContactInfoType.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
ContactInfo! ,
;, -
public 
enum 
ContactInfoType 
{ 
Phone 	
,	 

Telegram 
, 
Viber 	
,	 

WhatsApp 
}		 ö
yD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\ContactInfo\ContactInfoCreateModel.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
ContactInfo! ,
;, -
public 
record "
ContactInfoCreateModel $
($ %
string 

Type 
, 
string 

Value 
) 
; ²
nD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Domain\Common\ContactInfo\ContactInfo.cs
	namespace 	
Dealoviy
 
. 
Domain 
. 
Common  
.  !
ContactInfo! ,
;, -
public 
record 
ContactInfo 
{ 
public 

ContactInfoType 
Type 
{  !
get" %
;% &
}' (
public 

string 
Value 
{ 
get 
; 
}  
private		 
ContactInfo		 
(		 
ContactInfoType		 '
type		( ,
,		, -
string		. 4
value		5 :
)		: ;
{

 
Type 
= 
type 
; 
Value 
= 
value 
; 
} 
public 

static 
ErrorOr 
< 
ContactInfo %
>% &
Create' -
(- ."
ContactInfoCreateModel. D
modelE J
)J K
{ 
if 

( 
! 
Enum 
. 
TryParse 
< 
ContactInfoType *
>* +
(+ ,
model, 1
.1 2
Type2 6
,6 7
out8 ;
var< ?
type@ D
)D E
)E F
{ 	
return 
Errors 
. 
Errors  
.  !"
InvalidContactInfoType! 7
(7 8
model8 =
.= >
Type> B
)B C
;C D
} 	
return 
type 
switch 
{ 	
ContactInfoType 
. 
Phone !
or 
ContactInfoType "
." #
Viber# (
or 
ContactInfoType "
." #
WhatsApp# +
when 
! 
IsValidPhoneNumber (
(( )
model) .
.. /
Value/ 4
)4 5
=> 
Errors 
. 
Errors  
.  !
InvalidPhoneNumber! 3
(3 4
type4 8
)8 9
,9 :
ContactInfoType 
. 
Telegram $
when 
! 
IsValidUserHandle '
(' (
model( -
.- .
Value. 3
)3 4
=> 
Errors 
. 
Errors  
.  !
InvalidUserHandle! 2
(2 3
type3 7
)7 8
,8 9
_   
=>   
new   
ContactInfo    
(    !
type  ! %
,  % &
model  ' ,
.  , -
Value  - 2
)  2 3
}!! 	
;!!	 

}"" 
private$$ 
static$$ 
bool$$ 
IsValidPhoneNumber$$ *
($$* +
string$$+ 1
value$$2 7
)$$7 8
=>%% 

value%% 
.%% 
All%% 
(%% 
char%% 
.%% 
IsDigit%% !
)%%! "
&&&& 
value&& 
.&& 
Length&& 
==&& 
$num&& !
&&'' 
value'' 
.'' 

StartsWith'' 
(''  
$str''  %
)''% &
;''& '
private)) 
static)) 
bool)) 
IsValidUserHandle)) )
())) *
string))* 0
value))1 6
)))6 7
=>** 

value** 
.** 

StartsWith** 
(** 
$char** 
)**  
;**  !
}++ 
;++ 