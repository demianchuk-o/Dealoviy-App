©
uD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Users\Queries\GetById\UserResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Users $
.$ %
Queries% ,
., -
GetById- 4
;4 5
public 
record 

UserResult 
( 
Guid 
UserId $
,$ %
string& ,
Username- 5
,5 6
string7 =
?= >
DisplayName? J
,J K
GuidL P
?P Q
ContractorProfileIdR e
)e f
;f gÅ
ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Users\Queries\GetById\GetUserByIdQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Users $
.$ %
Queries% ,
., -
GetById- 4
;4 5
public		 
class		 #
GetUserByIdQueryHandler		 $
:

 
IRequestHandler

 
<

 
GetUserByIdQuery

 &
,

& '
ErrorOr

( /
<

/ 0

UserResult

0 :
>

: ;
>

; <
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public 
#
GetUserByIdQueryHandler "
(" #
IUserRepository# 2
userRepository3 A
)A B
{ 
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 

UserResult (
>( )
>) *
Handle+ 1
(1 2
GetUserByIdQuery2 B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 
if 

( 
await 
_userRepository !
.! "
GetUserByIdAsync" 2
(2 3
request3 :
.: ;
UserId; A
)A B
is 
not 
User 
user 
) 
{ 	
return 
Errors 
. 
UserNotFound &
;& '
} 	
return 
new 

UserResult 
( 
user 
. 
Id 
, 
user 
. 
Username 
, 
user 
. 
DisplayName 
, 
user 
. 
ContractorProfileId $
)$ %
;% &
}   
}!! Ó
{D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Users\Queries\GetById\GetUserByIdQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Users $
.$ %
Queries% ,
., -
GetById- 4
;4 5
public 
record 
GetUserByIdQuery 
( 
Guid #
UserId$ *
)* +
: 
IRequest 
< 
ErrorOr 
< 

UserResult !
>! "
>" #
;# $œ+
õD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetServicesWithStats\GetServicesWithStatsQueryHandler.cs
	namespace		 	
Dealoviy		
 
.		 
Application		 
.		 
Services		 '
.		' (
Queries		( /
.		/ 0 
GetServicesWithStats		0 D
;		D E
public 
class ,
 GetServicesWithStatsQueryHandler -
: 
IRequestHandler 
< %
GetServicesWithStatsQuery +
,+ ,
ErrorOr- 4
<4 5
IEnumerable5 @
<@ A#
ServiceTaskStatResponseA X
>X Y
>Y Z
>Z [
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
public 
,
 GetServicesWithStatsQueryHandler +
(+ ,
IUserRepository 
userRepository &
,& '
IServiceRepository 
serviceRepository ,
,, -
IRequestRepository 
requestRepository ,
,, -
IOrderRepository 
orderRepository (
)( )
{ 
_userRepository 
= 
userRepository (
;( )
_serviceRepository 
= 
serviceRepository .
;. /
_requestRepository 
= 
requestRepository .
;. /
_orderRepository 
= 
orderRepository *
;* +
} 
public 

async 
Task 
< 
ErrorOr 
< 
IEnumerable )
<) *#
ServiceTaskStatResponse* A
>A B
>B C
>C D
HandleE K
(K L%
GetServicesWithStatsQueryL e
requestf m
,m n
CancellationToken	o Ä
cancellationToken
Å í
)
í ì
{   
if!! 

(!! 
await!! 
_userRepository!! !
.!!! "
GetUserByIdAsync!!" 2
(!!2 3
request!!3 :
.!!: ;
UserId!!; A
)!!A B
is!!C E
not!!F I
{!!J K
}!!L M
user!!N R
)!!R S
{"" 	
return## 
Errors## 
.## 
UserNotFound## &
;##& '
}$$ 	
if&& 

(&&
 
user&& 
.&& 
ContractorProfileId&& #
is&&$ &
null&&' +
)&&+ ,
{'' 	
return(( 
Errors(( 
.((  
UserIsNotAContractor(( .
;((. /
})) 	
var++ 
services++ 
=++ 
await++ 
_serviceRepository++ /
.++/ 0"
GetByContractorIdAsync++0 F
(++F G
user++G K
.++K L
ContractorProfileId++L _
.++_ `
Value++` e
)++e f
;++f g
var,, 
serviceTaskStats,, 
=,, 
new,, "
List,,# '
<,,' (#
ServiceTaskStatResponse,,( ?
>,,? @
(,,@ A
),,A B
;,,B C
foreach.. 
(.. 
var.. 
service.. 
in.. 
services..  (
)..( )
{// 	
var00 
requests00 
=00 
await00  
_requestRepository00! 3
.003 4
GetByServiceIdAsync004 G
(00G H
service00H O
.00O P
Id00P R
)00R S
;00S T
var11  
pendingRequestsCount11 $
=11% &
requests11' /
.22 
Count22 
(22 
r22 
=>22 
r22 
.22 
RequestStatus22 +
==22, .
RequestStatus22/ <
.22< =
Pending22= D
)22D E
;22E F
var44 
orders44 
=44 
await44 
_orderRepository44 /
.44/ 0
GetByServiceIdAsync440 C
(44C D
service44D K
.44K L
Id44L N
)44N O
;44O P
var55 "
notFinishedOrdersCount55 &
=55' (
orders55) /
.66 
Count66 
(66 
o66 
=>66 
o66 
.66 
OrderStatus66 )
!=66* ,
OrderStatus66- 8
.668 9
Finished669 A
)66A B
;66B C
var88 
serviceTaskStat88 
=88  !
new88" %#
ServiceTaskStatResponse88& =
(88= >
service99 
.99 
Id99 
,99 
service:: 
.:: 
Name:: 
,::  
pendingRequestsCount;; $
,;;$ %"
notFinishedOrdersCount<< &
)<<& '
;<<' (
serviceTaskStats>> 
.>> 
Add>>  
(>>  !
serviceTaskStat>>! 0
)>>0 1
;>>1 2
}?? 	
returnAA 
serviceTaskStatsAA 
;AA  
}BB 
}CC Â
îD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetServicesWithStats\GetServicesWithStatsQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0 
GetServicesWithStats0 D
;D E
public 
record %
GetServicesWithStatsQuery '
(' (
Guid( ,
UserId- 3
)3 4
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" ##
ServiceTaskStatResponse# :
>: ;
>; <
>< =
;= >ÿ(
èD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetOwnServices\GetOwnServicesQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
GetOwnServices0 >
;> ?
public

 
class

 &
GetOwnServicesQueryHandler

 '
: 
IRequestHandler 
< 
GetOwnServicesQuery )
,) *
ErrorOr+ 2
<2 3
IEnumerable3 >
<> ?
ServiceResponse? N
>N O
>O P
>P Q
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
ICityRepository $
_cityRepository% 4
;4 5
public 
&
GetOwnServicesQueryHandler %
(% &
IUserRepository 
userRepository &
,& '
IServiceRepository 
serviceRepository ,
,, -
ICityRepository 
cityRepository &
)& '
{ 
_userRepository 
= 
userRepository (
;( )
_serviceRepository 
= 
serviceRepository .
;. /
_cityRepository 
= 
cityRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
IEnumerable )
<) *
ServiceResponse* 9
>9 :
>: ;
>; <
Handle= C
(C D
GetOwnServicesQueryD W
requestX _
,_ `
CancellationTokena r
cancellationToken	s Ñ
)
Ñ Ö
{ 
if 

( 
await 
_userRepository !
.! "
GetUserByIdAsync" 2
(2 3
request3 :
.: ;
UserId; A
)A B
is 
not 
{ 
} 
user 
) 
{ 	
return 
Errors 
. 
UserNotFound &
;& '
}   	
if"" 

("" 
user"" 
."" 
ContractorProfileId"" $
is""% '
null""( ,
)"", -
{## 	
return$$ 
Errors$$ 
.$$  
UserIsNotAContractor$$ .
;$$. /
}%% 	
var'' 
services'' 
='' 
await'' 
_serviceRepository'' /
.''/ 0"
GetByContractorIdAsync''0 F
(''F G
user''G K
.''K L
ContractorProfileId''L _
.''_ `
Value''` e
)''e f
;''f g
var)) 
citiesTasks)) 
=)) 
services)) "
.))" #
Select))# )
())) *
service))* 1
=>))2 4
_cityRepository))5 D
.))D E
GetCityByIdAsync))E U
())U V
service))V ]
.))] ^
CityId))^ d
)))d e
)))e f
;))f g
var++ 
cities++ 
=++ 
new++ 
List++ 
<++ 
City++ "
>++" #
(++# $
)++$ %
;++% &
foreach-- 
(-- 
var-- 
task-- 
in-- 
citiesTasks-- (
)--( )
{.. 	
cities// 
.// 
Add// 
(// 
await// 
task// !
)//! "
;//" #
}00 	
var22 
result22 
=22 
services22 
.22 
Zip22 !
(22! "
cities22" (
,22( )
(22* +
service22+ 2
,222 3
city224 8
)228 9
=>22: <
new22= @
ServiceResponse22A P
(22P Q
service33 
.33 
Id33 
,33 
service44 
.44 
ContractorId44  
,44  !
service55 
.55 
Name55 
,55 
city66 
.66 
Name66 
,66 
service77 
.77 
Description77 
,77  
service88 
.88 

PriceRange88 
.88 
Lower88 $
,88$ %
service99 
.99 

PriceRange99 
.99 
Upper99 $
,99$ %
service:: 
.:: 
AverageRating:: !
.::! "
Value::" '
,::' (
service;; 
.;; 
AverageRating;; !
.;;! "
Count;;" '
);;' (
);;( )
.<< 
ToList<< 
(<< 
)<< 
;<< 
return>> 
result>> 
;>> 
}?? 
}@@ ≈
àD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetOwnServices\GetOwnServicesQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
GetOwnServices0 >
;> ?
public 
record 
GetOwnServicesQuery !
(! "
Guid" &
UserId' -
)- .
:/ 0
IRequest1 9
<9 :
ErrorOr: A
<A B
IEnumerableB M
<M N
ServiceResponseN ]
>] ^
>^ _
>_ `
;` a
çD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetByKeywordAndCity\ServiceSearchResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
GetByKeywordAndCity0 C
;C D
public 
record 
ServiceSearchResult !
(! "
IEnumerable 
< 
ServiceResult 
> 
Services '
,' (
int 

TotalCount 
, 
string 

Keyword 
, 
string		 

CityName		 
)		 
;		 ƒ
ôD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetByKeywordAndCity\GetByKeywordAndCityQueryHandler.cs
	namespace		 	
Dealoviy		
 
.		 
Application		 
.		 
Services		 '
.		' (
Queries		( /
.		/ 0
GetByKeywordAndCity		0 C
;		C D
public 
class +
GetByKeywordAndCityQueryHandler ,
: 
IRequestHandler 
< $
GetByKeywordAndCityQuery .
,. /
ErrorOr0 7
<7 8
ServiceSearchResult8 K
>K L
>L M
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
ICityRepository $
_cityRepository% 4
;4 5
private 
readonly 
IMapper 
_mapper $
;$ %
public 
+
GetByKeywordAndCityQueryHandler *
(* +
IServiceRepository 
serviceRepository ,
,, -
ICityRepository 
cityRepository &
,& '
IMapper 
mapper 
) 
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_cityRepository 
= 
cityRepository (
;( )
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
ErrorOr 
< 
ServiceSearchResult 1
>1 2
>2 3
Handle4 :
(: ;$
GetByKeywordAndCityQuery  
request! (
,( )
CancellationToken 
cancellationToken +
)+ ,
{ 
if   

(  
 
await   
_cityRepository    
.    !
GetCityByIdAsync  ! 1
(  1 2
request  2 9
.  9 :
CityId  : @
)  @ A
is  B D
not  E H
City  I M
city  N R
)  R S
{!! 	
return"" 
Errors"" 
."" 
CityNotFound"" &
;""& '
}## 	
var%% 
services%% 
=%% 
await%% 
_serviceRepository%% /
.&& $
GetByKeywordAndCityAsync&& %
(&&% &
request&&& -
.&&- .
Keyword&&. 5
,&&5 6
request&&7 >
.&&> ?
CityId&&? E
)&&E F
;&&F G
var(( 
serviceResults(( 
=(( 
services(( %
.((% &
Select((& ,
(((, -
service((- 4
=>((5 7
_mapper)) 
.)) 
Map)) 
<)) 
ServiceResult)) %
>))% &
())& '
())' (
service))( /
,))/ 0
city))1 5
.))5 6
Name))6 :
))): ;
))); <
)))< =
.** 
OrderByDescending** 
(** 
s**  
=>**! #
s**$ %
.**% &
AverageRating**& 3
)**3 4
.++ 
ToList++ 
(++ 
)++ 
;++ 
return.. 
new.. 
ServiceSearchResult.. &
(..& '
serviceResults// 
,// 
serviceResults00 
.00 
Count00  
,00  !
request11 
.11 
Keyword11 
,11 
city22 
.22 
Name22 
)22 
;22 
}44 
}55 ﬁ
íD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetByKeywordAndCity\GetByKeywordAndCityQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
GetByKeywordAndCity0 C
;C D
public 
record $
GetByKeywordAndCityQuery &
(& '
string 

Keyword 
, 
Guid 
CityId	 
) 
: 
IRequest 
< 
ErrorOr #
<# $
ServiceSearchResult$ 7
>7 8
>8 9
;9 :ı
àD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetById\GetServiceByIdQueryHandler.cs
	namespace

 	
Dealoviy


 
.

 
Application

 
.

 
Services

 '
.

' (
Queries

( /
.

/ 0
GetById

0 7
;

7 8
public 
class &
GetServiceByIdQueryHandler '
: 
IRequestHandler 
< 
GetServiceByIdQuery )
,) *
ErrorOr+ 2
<2 3
ServiceResult3 @
>@ A
>A B
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
ICityRepository $
_cityRepository% 4
;4 5
private 
readonly 
IMapper 
_mapper $
;$ %
public 
&
GetServiceByIdQueryHandler %
(% &
IServiceRepository 
serviceRepository ,
,, -
ICityRepository 
cityRepository &
,& '
IMapper 
mapper 
) 
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_cityRepository 
= 
cityRepository (
;( )
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
ErrorOr 
< 
ServiceResult +
>+ ,
>, -
Handle. 4
(4 5
GetServiceByIdQuery5 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 
if 

( 
await 
_serviceRepository $
.$ %
GetByIdAsync% 1
(1 2
request2 9
.9 :
Id: <
)< =
is   
not   
Service   
service   "
)  " #
{!! 	
return"" 
Errors"" 
."" 
ServiceNotFound"" )
;"") *
}## 	
if%% 

(%% 
await%% 
_cityRepository%% !
.%%! "
GetCityByIdAsync%%" 2
(%%2 3
service%%3 :
.%%: ;
CityId%%; A
)%%A B
is&& 
not&& 
City&& 
city&& 
)&& 
{'' 	
return(( 
Errors(( 
.(( 
CityNotFound(( &
;((& '
})) 	
return++ 
_mapper++ 
.++ 
Map++ 
<++ 
ServiceResult++ (
>++( )
(++) *
(++* +
service+++ 2
,++2 3
city++4 8
.++8 9
Name++9 =
)++= >
)++> ?
;++? @
},, 
}-- ˙
ÅD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\GetById\GetServiceByIdQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
GetById0 7
;7 8
public 
record 
GetServiceByIdQuery !
(! "
Guid" &
Id' )
)) *
: 
IRequest 
< 
ErrorOr 
< 
ServiceResult $
>$ %
>% &
;& '∏
zD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Queries\Common\ServiceResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Queries( /
./ 0
Common0 6
;6 7
public 
record 
ServiceResult 
( 
Guid 
	ServiceId	 
, 
Guid 
ContractorId	 
, 
string 

Name 
, 
string 

CityName 
, 
string 

Description 
, 
int		 
LowerPriceBound		 
,		 
int

 
UpperPriceBound

 
,

 
double 

AverageRating 
, 
int 
ReviewsCount 
) 
; ≠
ãD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Common\Validators\ServiceCommandBaseValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Common( .
.. /

Validators/ 9
;9 :
public 
abstract 
class '
ServiceCommandBaseValidator 1
<1 2
TServiceCommand2 A
>A B
: 
AbstractValidator 
< 
TServiceCommand '
>' (
where 	
TServiceCommand
 
: 
IServiceCommand +
{		 
	protected

 '
ServiceCommandBaseValidator

 )
(

) *
)

* +
{ 
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str =
)= >
. 
WithMessage 
( 
$str 3
)3 4
;4 5
RuleFor 
( 
x 
=> 
x 
. 
Name 
) 
. 
MaximumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str >
)> ?
. 
WithMessage 
( 
$str L
)L M
;M N
RuleFor 
( 
x 
=> 
x 
. 
Description "
)" #
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str D
)D E
. 
WithMessage 
( 
$str :
): ;
;; <
RuleFor 
( 
x 
=> 
x 
. 
Description "
)" #
. 
MaximumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str E
)E F
. 
WithMessage 
( 
$str S
)S T
;T U
} 
}   Ω
D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Common\Interfaces\IServiceCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Common( .
.. /

Interfaces/ 9
;9 :
public 
	interface 
IServiceCommand  
{ 
Guid 
CityId	 
{ 
get 
; 
} 
string 

Name 
{ 
get 
; 
} 
string 

Description 
{ 
get 
; 
} 
int 
LowerPriceBound 
{ 
get 
; 
}  
int		 
UpperPriceBound		 
{		 
get		 
;		 
}		  
}

 ˘
ãD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Update\UpdateServiceCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Commands( 0
.0 1
Update1 7
;7 8
public 
class )
UpdateServiceCommandValidator *
: '
ServiceCommandBaseValidator !
<! " 
UpdateServiceCommand" 6
>6 7
{ 
public 
)
UpdateServiceCommandValidator (
(( )
)) *
:+ ,
base- 1
(1 2
)2 3
{		 
}

 
} ÷
âD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Update\UpdateServiceCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Commands( 0
.0 1
Update1 7
;7 8
public		 
class		 '
UpdateServiceCommandHandler		 (
:		) *
IRequestHandler		+ :
<		: ; 
UpdateServiceCommand		; O
,		O P
ErrorOr		Q X
<		X Y
Unit		Y ]
>		] ^
>		^ _
{

 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
ICityRepository $
_cityRepository% 4
;4 5
public 
'
UpdateServiceCommandHandler &
(& '
IServiceRepository' 9
serviceRepository: K
,K L
ICityRepositoryM \
cityRepository] k
)k l
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_cityRepository 
= 
cityRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ , 
UpdateServiceCommand, @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{ 
if 

(
 
await 
_cityRepository  
.  !
GetCityByIdAsync! 1
(1 2
request2 9
.9 :
CityId: @
)@ A
isB D
nullE I
)I J
{ 	
return 
Errors 
. 
CityNotFound &
;& '
} 	
if 

(
 
await 
_serviceRepository #
.# $
GetByIdAsync$ 0
(0 1
request1 8
.8 9
	ServiceId9 B
)B C
is 
not 
Service 
service !
)! "
{ 	
return 
Errors 
. 
ServiceNotFound )
;) *
} 	
var!! 
serviceResult!! 
=!! 
service!! #
.!!# $
Update!!$ *
(!!* +
request"" 
."" 
CityId"" 
,"" 
request## 
.## 
Name## 
,## 
request$$ 
.$$ 
Description$$ 
,$$  
request%% 
.%% 
LowerPriceBound%% #
,%%# $
request&& 
.&& 
UpperPriceBound&& #
)&&# $
;&&$ %
if(( 

((( 
serviceResult(( 
.(( 
IsError(( !
)((! "
{)) 	
return** 
serviceResult**  
.**  !
Errors**! '
;**' (
}++ 	
await-- 
_serviceRepository--  
.--  !
UpdateAsync--! ,
(--, -
serviceResult--- :
.--: ;
Value--; @
)--@ A
;--A B
return// 
Unit// 
.// 
Value// 
;// 
}00 
}11 ∆
ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Update\UpdateServiceCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Commands( 0
.0 1
Update1 7
;7 8
public 
record  
UpdateServiceCommand "
(" #
Guid 
	ServiceId	 
, 
Guid		 
CityId			 
,		 
string

 

Name

 
,

 
string 

Description 
, 
int 
LowerPriceBound 
, 
int 
UpperPriceBound 
) 
: 
IServiceCommand 
, 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
;  ˘
ãD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Create\CreateServiceCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Commands( 0
.0 1
Create1 7
;7 8
public 
class )
CreateServiceCommandValidator *
: '
ServiceCommandBaseValidator !
<! " 
CreateServiceCommand" 6
>6 7
{ 
public 
)
CreateServiceCommandValidator (
(( )
)) *
:+ ,
base- 1
(1 2
)2 3
{		 
}

 
} √
ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Create\CreateServiceCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Services '
.' (
Commands( 0
.0 1
Create1 7
;7 8
public 
record  
CreateServiceCommand "
(" #
Guid 
UserId	 
, 
Guid		 
CityId			 
,		 
string

 

Name

 
,

 
string 

Description 
, 
int 
LowerPriceBound 
, 
int 
UpperPriceBound 
) 
: 
IServiceCommand 
, 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
;  ç'
âD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Services\Commands\Create\CreateServiceCommandHandler.cs
	namespace		 	
Dealoviy		
 
.		 
Application		 
.		 
Services		 '
.		' (
Commands		( 0
.		0 1
Create		1 7
;		7 8
public 
class '
CreateServiceCommandHandler (
: 
IRequestHandler 
<  
CreateServiceCommand *
,* +
ErrorOr, 3
<3 4
Unit4 8
>8 9
>9 :
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
private 
readonly 
ICityRepository $
_cityRepository% 4
;4 5
public 
'
CreateServiceCommandHandler &
(& '
IUserRepository 
userRepository &
,& '
IServiceRepository 
serviceRepository ,
,, -(
IContractorProfileRepository $'
contractorProfileRepository% @
,@ A
ICityRepository 
cityRepository &
)& '
{ 
_userRepository 
= 
userRepository (
;( )
_serviceRepository 
= 
serviceRepository .
;. /(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
_cityRepository 
= 
cityRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ , 
CreateServiceCommand, @
requestA H
,H I
CancellationTokenJ [
cancellationToken\ m
)m n
{   
if!! 

(!! 
await!! 
_userRepository!! !
.!!! "
GetUserByIdAsync!!" 2
(!!2 3
request!!3 :
.!!: ;
UserId!!; A
)!!A B
is!!C E
not!!F I
User!!J N
user!!O S
)!!S T
{"" 	
return## 
Errors## 
.## 
UserNotFound## &
;##& '
}$$ 	
if&& 

(&& 
user&& 
.&& 
ContractorProfileId&& $
is&&% '
null&&( ,
)&&, -
{'' 	
return(( 
Errors(( 
.((  
UserIsNotAContractor(( .
;((. /
})) 	
if++ 

(++ 
await++ (
_contractorProfileRepository++ .
.++. /
GetByIdAsync++/ ;
(++; <
user++< @
.++@ A
ContractorProfileId++A T
.++T U
Value++U Z
)++Z [
is,, 
not,, 
ContractorProfile,, $
profile,,% ,
),,, -
{-- 	
return.. 
Errors.. 
... %
ContractorProfileNotFound.. 3
;..3 4
}// 	
if11 

(11 
await11 
_cityRepository11 !
.11! "
GetCityByIdAsync11" 2
(112 3
request113 :
.11: ;
CityId11; A
)11A B
is22 
null22 
)22 
{33 	
return44 
Errors44 
.44 
CityNotFound44 &
;44& '
}55 	
var77 
serviceResult77 
=77 
Service77 #
.77# $
Create77$ *
(77* +
profile88 
.88 
Id88 
,88 
request99 
.99 
CityId99 
,99 
request:: 
.:: 
Name:: 
,:: 
request;; 
.;; 
Description;; 
,;;  
request<< 
.<< 
LowerPriceBound<< #
,<<# $
request== 
.== 
UpperPriceBound== #
)==# $
;==$ %
if?? 

(?? 
serviceResult?? 
.?? 
IsError?? !
)??! "
{@@ 	
returnAA 
serviceResultAA  
.AA  !
ErrorsAA! '
;AA' (
}BB 	
awaitDD 
_serviceRepositoryDD  
.DD  !
AddAsyncDD! )
(DD) *
serviceResultDD* 7
.DD7 8
ValueDD8 =
)DD= >
;DD> ?
returnFF 
UnitFF 
.FF 
ValueFF 
;FF 
}GG 
}HH ≥$
öD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Reviews\Queries\GetReviewsForService\GetReviewsForServiceQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Reviews &
.& '
Queries' .
.. / 
GetReviewsForService/ C
;C D
public

 
class

 ,
 GetReviewsForServiceQueryHandler

 -
: 
IRequestHandler 
< %
GetReviewsForServiceQuery /
,/ 0
ErrorOr 
< 
IEnumerable 
< 
ReviewResponse *
>* +
>+ ,
>, -
{ 
private 
readonly 
IReviewRepository &
_reviewRepository' 8
;8 9
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public 
,
 GetReviewsForServiceQueryHandler +
(+ ,
IReviewRepository 
reviewRepository *
,* +
IServiceRepository 
serviceRepository ,
,, -
IUserRepository 
userRepository &
)& '
{ 
_reviewRepository 
= 
reviewRepository ,
;, -
_serviceRepository 
= 
serviceRepository .
;. /
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
IEnumerable )
<) *
ReviewResponse* 8
>8 9
>9 :
>: ;
Handle< B
(B C%
GetReviewsForServiceQuery !
request" )
,) *
CancellationToken 
cancellationToken +
)+ ,
{ 
if   

(   
await   
_serviceRepository   $
.  $ %
GetByIdAsync  % 1
(  1 2
request  2 9
.  9 :
	ServiceId  : C
)  C D
is!! 
null!! 
)!! 
{"" 	
return## 
Errors## 
.## 
ServiceNotFound## )
;##) *
}$$ 	
var&& 
reviews&& 
=&& 
await&& 
_reviewRepository&& -
.&&- .!
GetReviewsByServiceId&&. C
(&&C D
request&&D K
.&&K L
	ServiceId&&L U
)&&U V
;&&V W
var(( 
customerTasks(( 
=(( 
reviews(( #
.)) 
Select)) 
()) 
r)) 
=>)) 
_userRepository)) (
.))( )
GetUserByIdAsync))) 9
())9 :
r)): ;
.)); <
UserId))< B
)))B C
)))C D
;))D E
var++ 
	customers++ 
=++ 
new++ 
List++  
<++  !
User++! %
>++% &
(++& '
)++' (
;++( )
foreach-- 
(-- 
var-- 
task-- 
in-- 
customerTasks-- *
)--* +
{.. 	
	customers// 
.// 
Add// 
(// 
await// 
task//  $
)//$ %
;//% &
}00 	
var22 
reviewResponses22 
=22 
reviews22 %
.33 
Zip33 
(33 
	customers33 
,33 
(33 
review33 #
,33# $
customer33% -
)33- .
=>33/ 1
new332 5
ReviewResponse336 D
(33D E
review44 
.44 
Id44 
,44 
customer55 
.55 
GetDisplayName55 '
(55' (
)55( )
,55) *
review66 
.66 
Text66 
,66 
review77 
.77 
	CreatedAt77  
,77  !
review88 
.88 
Rating88 
)88 
)88 
.99 
OrderByDescending99 
(99 
r99  
=>99! #
r99$ %
.99% &

ReviewDate99& 0
)990 1
.:: 
ToList:: 
(:: 
):: 
;:: 
return<< 
reviewResponses<< 
;<< 
}== 
}>> ›
ìD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Reviews\Queries\GetReviewsForService\GetReviewsForServiceQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Reviews &
.& '
Queries' .
.. / 
GetReviewsForService/ C
;C D
public 
record %
GetReviewsForServiceQuery '
(' (
Guid( ,
	ServiceId- 6
)6 7
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" #
ReviewResponse# 1
>1 2
>2 3
>3 4
;4 5”
õD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Reviews\Commands\AddReviewOnService\AddReviewOnServiceCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Reviews &
.& '
Commands' /
./ 0
AddReviewOnService0 B
;B C
public 
class .
"AddReviewOnServiceCommandValidator /
: 
AbstractValidator 
< %
AddReviewOnServiceCommand 1
>1 2
{ 
public 
.
"AddReviewOnServiceCommandValidator -
(- .
). /
{		 
RuleFor

 
(

 
c

 
=>

 
c

 
.

 
	ServiceId

  
)

  !
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str 6
)6 7
. 
WithMessage 
( 
$str 2
)2 3
;3 4
RuleFor 
( 
c 
=> 
c 
. 
UserId 
) 
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str 3
)3 4
. 
WithMessage 
( 
$str /
)/ 0
;0 1
RuleFor 
( 
c 
=> 
c 
. 
Rating 
) 
. 
InclusiveBetween 
( 
$num 
,  
$num! "
)" #
. 
WithErrorCode 
( 
$str 2
)2 3
. 
WithMessage 
( 
$str :
): ;
;; <
RuleFor 
( 
c 
=> 
c 
. 
Text 
) 
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str 1
)1 2
. 
WithMessage 
( 
$str ,
), -
;- .
RuleFor 
( 
c 
=> 
c 
. 
Text 
) 
. 
MaximumLength 
( 
$num 
) 
.   
WithErrorCode   
(   
$str   0
)  0 1
.!! 
WithMessage!! 
(!! 
$str!! A
)!!A B
;!!B C
}"" 
}## à!
ôD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Reviews\Commands\AddReviewOnService\AddReviewOnServiceCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Reviews &
.& '
Commands' /
./ 0
AddReviewOnService0 B
;B C
public		 
class		 ,
 AddReviewOnServiceCommandHandler		 -
:

 
IRequestHandler

 
<

 %
AddReviewOnServiceCommand

 /
,

/ 0
ErrorOr

1 8
<

8 9
Unit

9 =
>

= >
>

> ?
{ 
private 
readonly 
IReviewRepository &
_reviewRepository' 8
;8 9
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IDateTimeProvider &
_dateTimeProvider' 8
;8 9
public 
,
 AddReviewOnServiceCommandHandler +
(+ ,
IReviewRepository 
reviewRepository *
,* +
IUserRepository 
userRepository &
,& '
IServiceRepository 
serviceRepository ,
,, -
IDateTimeProvider 
dateTimeProvider *
)* +
{ 
_reviewRepository 
= 
reviewRepository ,
;, -
_userRepository 
= 
userRepository (
;( )
_serviceRepository 
= 
serviceRepository .
;. /
_dateTimeProvider 
= 
dateTimeProvider ,
;, -
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,%
AddReviewOnServiceCommand, E
requestF M
,M N
CancellationTokenO `
cancellationTokena r
)r s
{ 
if 

( 
await 
_serviceRepository $
.$ %
GetByIdAsync% 1
(1 2
request2 9
.9 :
	ServiceId: C
)C D
is   
not   
{   
}   
service   
)   
{!! 	
return"" 
Errors"" 
."" 
ServiceNotFound"" )
;"") *
}## 	
if%% 

(%% 
await%% 
_userRepository%% !
.%%! "
GetUserByIdAsync%%" 2
(%%2 3
request%%3 :
.%%: ;
UserId%%; A
)%%A B
is&& 
null&& 
)&& 
{'' 	
return(( 
Errors(( 
.(( 
UserNotFound(( &
;((& '
})) 	
var++ 
review++ 
=++ 
Review++ 
.++ 
Create++ "
(++" #
request,, 
.,, 
	ServiceId,, 
,,, 
request-- 
.-- 
UserId-- 
,-- 
request.. 
... 
Rating.. 
,.. 
request// 
.// 
Text// 
,// 
_dateTimeProvider00 
.00 
UtcNow00 $
)00$ %
;00% &
await22 
_reviewRepository22 
.22  
	AddReview22  )
(22) *
review22* 0
)220 1
;221 2
service44 
.44 
AverageRating44 
.44 
	AddRating44 '
(44' (
review44( .
.44. /
Rating44/ 5
)445 6
;446 7
await55 
_serviceRepository55  
.55  !
UpdateAsync55! ,
(55, -
service55- 4
)554 5
;555 6
return77 
Unit77 
.77 
Value77 
;77 
}88 
}99 ∏
íD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Reviews\Commands\AddReviewOnService\AddReviewOnServiceCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Reviews &
.& '
Commands' /
./ 0
AddReviewOnService0 B
;B C
public 
record %
AddReviewOnServiceCommand '
(' (
Guid 
	ServiceId	 
, 
Guid 
UserId	 
, 
int		 
Rating		 
,		 
string

 

Text

 
)

 
:

 
IRequest

 
<

 
ErrorOr

 #
<

# $
Unit

$ (
>

( )
>

) *
;

* +†:
óD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Queries\GetRequestsForUser\GetRequestsForUserQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Queries( /
./ 0
GetRequestsForUser0 B
;B C
public 
class *
GetRequestsForUserQueryHandler +
: 
IRequestHandler 
< #
GetRequestsForUserQuery -
,- .
ErrorOr/ 6
<6 7
IEnumerable7 B
<B C
UserRequestResponseC V
>V W
>W X
>X Y
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IMapper 
_mapper $
;$ %
private 
readonly 
IDateTimeProvider &
_dateTimeProvider' 8
;8 9
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
public 
*
GetRequestsForUserQueryHandler )
() *
IServiceRepository 
serviceRepository ,
,, -
IRequestRepository 
requestRepository ,
,, -
IMapper 
mapper 
, 
IDateTimeProvider 
dateTimeProvider *
,* +
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
)@ A
{ 
_serviceRepository   
=   
serviceRepository   .
;  . /
_requestRepository!! 
=!! 
requestRepository!! .
;!!. /
_mapper"" 
="" 
mapper"" 
;"" 
_dateTimeProvider## 
=## 
dateTimeProvider## ,
;##, -
_userRepository$$ 
=$$ 
userRepository$$ (
;$$( )(
_contractorProfileRepository%% $
=%%% &'
contractorProfileRepository%%' B
;%%B C
}&& 
public(( 

async(( 
Task(( 
<(( 
ErrorOr(( 
<(( 
IEnumerable(( )
<(() *
UserRequestResponse((* =
>((= >
>((> ?
>((? @
Handle((A G
(((G H#
GetRequestsForUserQuery((H _
request((` g
,((g h
CancellationToken((i z
cancellationToken	(({ å
)
((å ç
{)) 
var** 
requests** 
=** 
await** 
_requestRepository** /
.**/ 0 
GetByCustomerIdAsync**0 D
(**D E
request**E L
.**L M
UserId**M S
)**S T
;**T U
var,, 
servicesTasks,, 
=,, 
requests,, $
.-- 
Select-- 
(-- 
r-- 
=>-- 
_serviceRepository-- +
.--+ ,
GetByIdAsync--, 8
(--8 9
r--9 :
.--: ;
	ServiceId--; D
)--D E
)--E F
;--F G
var// 
services// 
=// 
new// 
List// 
<//  
Service//  '
>//' (
(//( )
)//) *
;//* +
foreach11 
(11 
var11 
task11 
in11 
servicesTasks11 *
)11* +
{22 	
services33 
.33 
Add33 
(33 
await33 
task33 #
)33# $
;33$ %
}44 	
var66 
contractorTasks66 
=66 
services66 &
.77 
Select77 
(77 
s77 
=>77 (
_contractorProfileRepository77 5
.775 6
GetByIdAsync776 B
(77B C
s77C D
.77D E
ContractorId77E Q
)77Q R
)77R S
;77S T
var99 
contractors99 
=99 
new99 
List99 "
<99" #
ContractorProfile99# 4
>994 5
(995 6
)996 7
;997 8
foreach;; 
(;; 
var;; 
task;; 
in;; 
contractorTasks;; ,
);;, -
{<< 	
contractors== 
.== 
Add== 
(== 
await== !
task==" &
)==& '
;==' (
}>> 	
var@@ 

usersTasks@@ 
=@@ 
contractors@@ $
.AA 
SelectAA 
(AA 
cAA 
=>AA 
_userRepositoryAA (
.AA( )"
GetByContractorIdAsyncAA) ?
(AA? @
cAA@ A
.AAA B
IdAAB D
)AAD E
)AAE F
;AAF G
varCC 
usersCC 
=CC 
newCC 
ListCC 
<CC 
UserCC !
>CC! "
(CC" #
)CC# $
;CC$ %
foreachEE 
(EE 
varEE 
taskEE 
inEE 

usersTasksEE '
)EE' (
{FF 	
usersGG 
.GG 
AddGG 
(GG 
awaitGG 
taskGG  
)GG  !
;GG! "
}HH 	
returnJJ 
requestsJJ 
.KK 
SelectKK 
(KK 
(KK 
rKK 
,KK 
iKK 
)KK 
=>KK 
newKK !
UserRequestResponseKK" 5
(KK5 6
rLL 
.LL 
IdLL 
,LL 
rMM 
.MM 
DescriptionMM 
,MM 
rNN 
.NN 
PaymentAmountNN 
,NN  
rOO 
.OO 
RequestDateOO 
,OO 
rPP 
.PP 
RequestStatusPP 
.PP  
ToStringPP  (
(PP( )
)PP) *
,PP* +
usersQQ 
[QQ 
iQQ 
]QQ 
.QQ 
GetDisplayNameQQ '
(QQ' (
)QQ( )
,QQ) *
servicesRR 
[RR 
iRR 
]RR 
.RR 
IdRR 
,RR 
servicesSS 
[SS 
iSS 
]SS 
.SS 
NameSS  
,SS  !
newTT 
ContactInfoResponseTT '
(TT' (
rUU 
.UU !
ContractorContactInfoUU +
.UU+ ,
TypeUU, 0
.UU0 1
ToStringUU1 9
(UU9 :
)UU: ;
,UU; <
rVV 
.VV !
ContractorContactInfoVV +
.VV+ ,
ValueVV, 1
)VV1 2
)VV2 3
)VV3 4
.WW 
OrderByDescendingWW 
(WW 
rWW  
=>WW! #
rWW$ %
.WW% &
RequestDateWW& 1
)WW1 2
.XX 
ToListXX 
(XX 
)XX 
;XX 
}YY 
}ZZ Ÿ
êD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Queries\GetRequestsForUser\GetRequestsForUserQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Queries( /
./ 0
GetRequestsForUser0 B
;B C
public 
record #
GetRequestsForUserQuery %
(% &
Guid& *
UserId+ 1
)1 2
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" #
UserRequestResponse# 6
>6 7
>7 8
>8 9
;9 :±,
ùD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Queries\GetRequestsForService\GetRequestsForServiceQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Queries( /
./ 0!
GetRequestsForService0 E
;E F
public 
class -
!GetRequestsForServiceQueryHandler .
: 
IRequestHandler 
< &
GetRequestsForServiceQuery 0
,0 1
ErrorOr 
< 
IEnumerable 
< "
ServiceRequestResponse 2
>2 3
>3 4
>4 5
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IMapper 
_mapper $
;$ %
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public 
-
!GetRequestsForServiceQueryHandler ,
(, -
IServiceRepository 
serviceRepository ,
,, -
IRequestRepository 
requestRepository ,
,, -
IMapper 
mapper 
, 
IUserRepository 
userRepository &
)& '
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_requestRepository 
= 
requestRepository .
;. /
_mapper 
= 
mapper 
; 
_userRepository 
= 
userRepository (
;( )
}   
public"" 

async"" 
Task"" 
<"" 
ErrorOr"" 
<"" 
IEnumerable"" )
<"") *"
ServiceRequestResponse""* @
>""@ A
>""A B
>""B C
Handle## 
(## &
GetRequestsForServiceQuery## )
request##* 1
,##1 2
CancellationToken$$ 
cancellationToken$$ /
)$$/ 0
{%% 
if&& 

(&& 
await&& 
_serviceRepository&& $
.&&$ %
GetByIdAsync&&% 1
(&&1 2
request&&2 9
.&&9 :
	ServiceId&&: C
)&&C D
is'' 
not'' 
{'' 
}'' 
service'' 
)'' 
{(( 	
return)) 
Errors)) 
.)) 
ServiceNotFound)) )
;))) *
}** 	
var-- 
requests-- 
=-- 
await-- 
_requestRepository-- /
.--/ 0
GetByServiceIdAsync--0 C
(--C D
service--D K
.--K L
Id--L N
)--N O
;--O P
requests.. 
=.. 
requests.. 
... 
Where.. !
(..! "
r.." #
=>..$ &
r..' (
...( )
RequestStatus..) 6
==..7 9
RequestStatus..: G
...G H
Pending..H O
)..O P
;..P Q
var11 
customersTasks11 
=11 
requests11 %
.22 
Select22 
(22 
r22 
=>22 
_userRepository22 (
.22( )
GetUserByIdAsync22) 9
(229 :
r22: ;
.22; <

CustomerId22< F
)22F G
)22G H
;22H I
var44 
	customers44 
=44 
new44 
List44  
<44  !
User44! %
>44% &
(44& '
)44' (
;44( )
foreach66 
(66 
var66 
task66 
in66 
customersTasks66 +
)66+ ,
{77 	
	customers88 
.88 
Add88 
(88 
await88 
task88  $
)88$ %
;88% &
}99 	
return== 
requests== 
.>> 
Select>> 
(>> 
(>> 
r>> 
,>> 
i>> 
)>> 
=>>> 
new>> !"
ServiceRequestResponse>>" 8
(>>8 9
r?? 
.?? 
Id?? 
,?? 
r@@ 
.@@ 
Description@@ 
,@@ 
rAA 
.AA 
PaymentAmountAA 
,AA  
rBB 
.BB 
RequestDateBB 
,BB 
rCC 
.CC 
RequestStatusCC 
.CC  
ToStringCC  (
(CC( )
)CC) *
,CC* +
	customersDD 
[DD 
iDD 
]DD 
.DD 
GetDisplayNameDD +
(DD+ ,
)DD, -
,DD- .
newEE 
ContactInfoResponseEE '
(EE' (
rFF 
.FF 
CustomerContactInfoFF )
.FF) *
TypeFF* .
.FF. /
ToStringFF/ 7
(FF7 8
)FF8 9
,FF9 :
rGG 
.GG 
CustomerContactInfoGG )
.GG) *
ValueGG* /
)GG/ 0
)HH 
)HH 
.II 
OrderByDescendingII 
(II 
rII  
=>II! #
rII$ %
.II% &
RequestDateII& 1
)II1 2
.JJ 
ToListJJ 
(JJ 
)JJ 
;JJ 
}KK 
}LL Î
ñD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Queries\GetRequestsForService\GetRequestsForServiceQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Queries( /
./ 0!
GetRequestsForService0 E
;E F
public 
record &
GetRequestsForServiceQuery (
(( )
Guid) -
	ServiceId. 7
)7 8
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" #"
ServiceRequestResponse# 9
>9 :
>: ;
>; <
;< =˛
ùD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\DeleteIfDeclined\DeleteRequestIfDeclinedCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
DeleteIfDeclined1 A
;A B
public 
class 1
%DeleteRequestIfDeclinedCommandHandler 2
:		 
IRequestHandler		 
<		 *
DeleteRequestIfDeclinedCommand		 4
,		4 5
ErrorOr

 
<

 
Unit

 
>

 
>

 
{ 
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public 
1
%DeleteRequestIfDeclinedCommandHandler 0
(0 1
IRequestRepository 
requestRepository ,
,, -
IUserRepository 
userRepository &
)& '
{ 
_requestRepository 
= 
requestRepository .
;. /
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,*
DeleteRequestIfDeclinedCommand, J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 
var 
requestEntity 
= 
await !
_requestRepository" 4
.4 5
GetByIdAsync5 A
(A B
requestB I
.I J
	RequestIdJ S
)S T
;T U
if 

(
 
requestEntity 
is 
null  
)  !
return 
Error 
. 
NotFound !
(! "
$str" 5
)5 6
;6 7
var 
customer 
= 
await 
_userRepository ,
., -
GetUserByIdAsync- =
(= >
request> E
.E F
UserCustomerIdF T
)T U
;U V
if 

(
 
customer 
is 
null 
) 
return 
Error 
. 
NotFound !
(! "
$str" 6
)6 7
;7 8
if!! 

(!!
 
requestEntity!! 
.!! 
RequestStatus!! &
==!!' )
RequestStatus!!* 7
.!!7 8
Declined!!8 @
)!!@ A
await"" 
_requestRepository"" $
.""$ %
DeleteAsync""% 0
(""0 1
requestEntity""1 >
)""> ?
;""? @
return$$ 
Unit$$ 
.$$ 
Value$$ 
;$$ 
}%% 
}&& ﬂ
ñD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\DeleteIfDeclined\DeleteRequestIfDeclinedCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
DeleteIfDeclined1 A
;A B
public 
record *
DeleteRequestIfDeclinedCommand ,
(, -
Guid- 1
	RequestId2 ;
,; <
Guid= A
UserCustomerIdB P
)P Q
: 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; è 
íD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\DeclineRequest\DeclineRequestCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
DeclineRequest1 ?
;? @
public 
class (
DeclineRequestCommandHandler )
:		 
IRequestHandler		 
<		 !
DeclineRequestCommand		 +
,		+ ,
ErrorOr		- 4
<		4 5
Unit		5 9
>		9 :
>		: ;
{

 
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
public 
(
DeclineRequestCommandHandler '
(' (
IRequestRepository 
requestRepository ,
,, -
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
)@ A
{ 
_requestRepository 
= 
requestRepository .
;. /
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,!
DeclineRequestCommand, A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 
var 
requestEntity 
= 
await !
_requestRepository" 4
.4 5
GetByIdAsync5 A
(A B
requestB I
.I J
	RequestIdJ S
)S T
;T U
if 

( 
requestEntity 
is 
null !
)! "
return 
Error 
. 
NotFound !
(! "
$str" 5
)5 6
;6 7
var   

contractor   
=   
await   
_userRepository   .
.  . /
GetUserByIdAsync  / ?
(  ? @
request  @ G
.  G H
UserContractorId  H X
)  X Y
;  Y Z
if!! 

(!!
 

contractor!! 
.!! 
ContractorProfileId!! )
is!!* ,
null!!- 1
)!!1 2
return"" 
Error"" 
."" 
NotFound"" !
(""! "
$str""" 8
)""8 9
;""9 :
var$$ 
contractorProfile$$ 
=$$ 
await$$  %(
_contractorProfileRepository$$& B
.$$B C
GetByIdAsync$$C O
($$O P

contractor$$P Z
.$$Z [
ContractorProfileId$$[ n
.$$n o
Value$$o t
)$$t u
;$$u v
if&& 

(&& 
contractorProfile&& 
is&&  
null&&! %
)&&% &
return'' 
Error'' 
.'' 
NotFound'' !
(''! "
$str''" @
)''@ A
;''A B
requestEntity)) 
.)) 
UpdateRequestStatus)) )
())) *
RequestStatus))* 7
.))7 8
Declined))8 @
)))@ A
;))A B
await++ 
_requestRepository++  
.++  !
UpdateAsync++! ,
(++, -
requestEntity++- :
)++: ;
;++; <
return-- 
Unit-- 
.-- 
Value-- 
;-- 
}.. 
}// À
ãD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\DeclineRequest\DeclineRequestCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
DeclineRequest1 ?
;? @
public 
record !
DeclineRequestCommand #
(# $
Guid$ (
	RequestId) 2
,2 3
Guid4 8
UserContractorId9 I
)I J
: 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; …+
âD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\Create\CreateRequestCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
Create1 7
;7 8
public 
class '
CreateRequestCommandHandler (
: 
IRequestHandler 
<  
CreateRequestCommand *
,* +
ErrorOr, 3
<3 4
Unit4 8
>8 9
>9 :
{ 
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
private 
readonly 
IDateTimeProvider &
_dateTimeProvider' 8
;8 9
public 
'
CreateRequestCommandHandler &
(& '
IRequestRepository 
requestRepository ,
,, -
IServiceRepository 
serviceRepository ,
,, -
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
,@ A
IDateTimeProvider 
dateTimeProvider *
)* +
{ 
_requestRepository 
= 
requestRepository .
;. /
_serviceRepository 
= 
serviceRepository .
;. /
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository   $
=  % &'
contractorProfileRepository  ' B
;  B C
_dateTimeProvider!! 
=!! 
dateTimeProvider!! ,
;!!, -
}"" 
public$$ 

async$$ 
Task$$ 
<$$ 
ErrorOr$$ 
<$$ 
Unit$$ "
>$$" #
>$$# $
Handle$$% +
($$+ , 
CreateRequestCommand$$, @
request$$A H
,$$H I
CancellationToken$$J [
cancellationToken$$\ m
)$$m n
{%% 
if&& 

(&& 
await&& 
_serviceRepository&& $
.&&$ %
GetByIdAsync&&% 1
(&&1 2
request&&2 9
.&&9 :
	ServiceId&&: C
)&&C D
is'' 
not'' 
Service'' 
service'' "
)''" #
{(( 	
return)) 
Errors)) 
.)) 
ServiceNotFound)) )
;))) *
}** 	
if,, 

(,, 
await,, 
_userRepository,, !
.,,! "
GetUserByIdAsync,," 2
(,,2 3
request,,3 :
.,,: ;

CustomerId,,; E
),,E F
is,,G I
null,,J N
),,N O
{-- 	
return.. 
Errors.. 
... 
UserNotFound.. &
;..& '
}// 	
var11 

contractor11 
=11 
await11 (
_contractorProfileRepository11 ;
.11; <
GetByIdAsync11< H
(11H I
service11I P
.11P Q
ContractorId11Q ]
)11] ^
;11^ _
var22 !
contractorContactInfo22 !
=22" #

contractor22$ .
.22. /
ContactInfos22/ ;
.33 
FirstOrDefault33 
(33 
ci33 
=>33 !
ci33" $
.33$ %
Type33% )
.33) *
ToString33* 2
(332 3
)333 4
==335 7
request338 ?
.33? @
CustomerContactInfo33@ S
.33S T
Type33T X
)33X Y
;33Y Z
var44 
requestResult44 
=44 
Request44 #
.44# $
Create44$ *
(44* +
request55 
.55 

CustomerId55 
,55 
request66 
.66 
	ServiceId66 
,66 
request77 
.77 
Description77 
,77  
request88 
.88 
PaymentAmount88 !
,88! "
_dateTimeProvider99 
.99 
UtcNow99 $
,99$ %
RequestStatus:: 
.:: 
Pending:: !
,::! "
request;; 
.;; 
CustomerContactInfo;; '
.;;' (
Adapt;;( -
<;;- ."
ContactInfoCreateModel;;. D
>;;D E
(;;E F
);;F G
,;;G H!
contractorContactInfo<< !
)== 
;== 
if?? 

(?? 
requestResult?? 
.?? 
IsError?? !
)??! "
{@@ 	
returnAA 
requestResultAA  
.AA  !
ErrorsAA! '
;AA' (
}BB 	
awaitDD 
_requestRepositoryDD  
.DD  !
AddAsyncDD! )
(DD) *
requestResultDD* 7
.DD7 8
ValueDD8 =
)DD= >
;DD> ?
returnFF 
UnitFF 
.FF 
ValueFF 
;FF 
}GG 
}HH ¯
ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\Create\CreateRequestCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
Create1 7
;7 8
public 
record  
CreateRequestCommand "
(" #
Guid 
	ServiceId 
, 
Guid 

CustomerId 
, 
string		 
Description		 
,		 
ContactInfoModel

 
CustomerContactInfo

 ,
,

, -
int 
PaymentAmount 
) 
: 
IRequest %
<% &
ErrorOr& -
<- .
Unit. 2
>2 3
>3 4
;4 5†&
êD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\AcceptRequest\AcceptRequestCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
AcceptRequest1 >
;> ?
public		 
class		 '
AcceptRequestCommandHandler		 (
:

 
IRequestHandler

 
<

  
AcceptRequestCommand

 *
,

* +
ErrorOr

, 3
<

3 4
Unit

4 8
>

8 9
>

9 :
{ 
private 
readonly 
IRequestRepository '
_requestRepository( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
private 
readonly 
IDateTimeProvider &
_dateTimeProvider' 8
;8 9
public 
'
AcceptRequestCommandHandler &
(& '
IRequestRepository 
requestRepository ,
,, -
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
,@ A
IOrderRepository 
orderRepository (
,( )
IDateTimeProvider 
dateTimeProvider *
)* +
{ 
_requestRepository 
= 
requestRepository .
;. /
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
_orderRepository 
= 
orderRepository *
;* +
_dateTimeProvider 
= 
dateTimeProvider ,
;, -
} 
public   

async   
Task   
<   
ErrorOr   
<   
Unit   "
>  " #
>  # $
Handle  % +
(  + , 
AcceptRequestCommand  , @
request  A H
,  H I
CancellationToken  J [
cancellationToken  \ m
)  m n
{!! 
var"" 
requestEntity"" 
="" 
await"" !
_requestRepository""" 4
.""4 5
GetByIdAsync""5 A
(""A B
request""B I
.""I J
	RequestId""J S
)""S T
;""T U
if$$ 

($$ 
requestEntity$$ 
is$$ 
null$$ !
)$$! "
return%% 
Error%% 
.%% 
NotFound%% !
(%%! "
$str%%" 5
)%%5 6
;%%6 7
var'' 

contractor'' 
='' 
await'' 
_userRepository'' .
.''. /
GetUserByIdAsync''/ ?
(''? @
request''@ G
.''G H
UserContractorId''H X
)''X Y
;''Y Z
if(( 

(((
 

contractor(( 
.(( 
ContractorProfileId(( )
is((* ,
null((- 1
)((1 2
return)) 
Error)) 
.)) 
NotFound)) !
())! "
$str))" 8
)))8 9
;))9 :
var++ 
contractorProfile++ 
=++ 
await++  %(
_contractorProfileRepository++& B
.++B C
GetByIdAsync++C O
(++O P

contractor++P Z
.++Z [
ContractorProfileId++[ n
.++n o
Value++o t
)++t u
;++u v
if-- 

(-- 
contractorProfile-- 
is--  
null--! %
)--% &
return.. 
Error.. 
... 
NotFound.. !
(..! "
$str.." @
)..@ A
;..A B
var00 
order00 
=00 
Order00 
.00 
Create00  
(00  !
requestEntity00! .
,00. /
_dateTimeProvider11 
.11 
UtcNow11 $
)11$ %
;11% &
await22 
_orderRepository22 
.22 
AddAsync22 '
(22' (
order22( -
)22- .
;22. /
await44 
_requestRepository44  
.44  !
DeleteAsync44! ,
(44, -
requestEntity44- :
)44: ;
;44; <
return66 
Unit66 
.66 
Value66 
;66 
}77 
}88 «
âD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Requests\Commands\AcceptRequest\AcceptRequestCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Requests '
.' (
Commands( 0
.0 1
AcceptRequest1 >
;> ?
public 
record  
AcceptRequestCommand "
(" #
Guid# '
	RequestId( 1
,1 2
Guid3 7
UserContractorId8 H
)H I
: 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; ‘
~D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Regions\Queries\GetRegion\GetRegionsQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Regions &
.& '
Queries' .
.. /
	GetRegion/ 8
;8 9
public 
record 
GetRegionsQuery 
( 
) 
:  !
IRequest" *
<* +
IEnumerable+ 6
<6 7
RegionResult7 C
>C D
>D E
;E Fö
ÑD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Regions\Queries\GetRegion\GetRegionQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Regions &
.& '
Queries' .
.. /
	GetRegion/ 8
;8 9
public 
class !
GetRegionQueryHandler "
:# $
IRequestHandler% 4
<4 5
GetRegionsQuery5 D
,D E
IEnumerableF Q
<Q R
RegionResultR ^
>^ _
>_ `
{		 
private

 
readonly

 
IRegionRepository

 &
_regionRepository

' 8
;

8 9
private 
readonly 
IMapper 
_mapper $
;$ %
public 
!
GetRegionQueryHandler  
(  !
IRegionRepository 
regionRepository *
,* +
IMapper 
mapper 
) 
{ 
_regionRepository 
= 
regionRepository ,
;, -
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
IEnumerable !
<! "
RegionResult" .
>. /
>/ 0
Handle1 7
(7 8
GetRegionsQuery8 G
requestH O
,O P
CancellationTokenQ b
cancellationTokenc t
)t u
{ 
var 
regions 
= 
await 
_regionRepository -
.- .
GetAllRegionsAsync. @
(@ A
)A B
;B C
return 
_mapper 
. 
Map 
< 
IEnumerable &
<& '
RegionResult' 3
>3 4
>4 5
(5 6
regions6 =
)= >
;> ?
} 
} ﬂ
pD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Regions\Common\RegionResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Regions &
.& '
Common' -
;- .
public 
record 
RegionResult 
( 
Guid 
Id	 
, 
string 

Name 
) 
; È5
ëD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Queries\GetOrdersForUser\GetOrdersForUserQueryHandler.cs
	namespace

 	
Dealoviy


 
.

 
Application

 
.

 
Orders

 %
.

% &
Queries

& -
.

- .
GetOrdersForUser

. >
;

> ?
public 
class (
GetOrdersForUserQueryHandler )
: 
IRequestHandler 
< !
GetOrdersForUserQuery '
,' (
ErrorOr) 0
<0 1
IEnumerable1 <
<< =
UserOrderResponse= N
>N O
>O P
>P Q
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
public 
(
GetOrdersForUserQueryHandler '
(' (
IServiceRepository 
serviceRepository ,
,, -
IOrderRepository 
orderRepository (
,( )
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
)@ A
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_orderRepository 
= 
orderRepository *
;* +
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
} 
public   

async   
Task   
<   
ErrorOr   
<   
IEnumerable   )
<  ) *
UserOrderResponse  * ;
>  ; <
>  < =
>  = >
Handle  ? E
(  E F!
GetOrdersForUserQuery!! 
request!! %
,!!% &
CancellationToken"" 
cancellationToken"" +
)""+ ,
{## 
var$$ 
orders$$ 
=$$ 
await$$ 
_orderRepository$$ +
.$$+ , 
GetByCustomerIdAsync$$, @
($$@ A
request$$A H
.$$H I
UserId$$I O
)$$O P
;$$P Q
var&& 
servicesTasks&& 
=&& 
orders&& "
.'' 
Select'' 
('' 
r'' 
=>'' 
_serviceRepository'' +
.''+ ,
GetByIdAsync'', 8
(''8 9
r''9 :
.'': ;
	ServiceId''; D
)''D E
)''E F
;''F G
var)) 
services)) 
=)) 
new)) 
List)) 
<))  
Service))  '
>))' (
())( )
)))) *
;))* +
foreach++ 
(++ 
var++ 
task++ 
in++ 
servicesTasks++ *
)++* +
{,, 	
services-- 
.-- 
Add-- 
(-- 
await-- 
task-- #
)--# $
;--$ %
}.. 	
var00 
contractorTasks00 
=00 
services00 &
.11 
Select11 
(11 
s11 
=>11 (
_contractorProfileRepository11 5
.115 6
GetByIdAsync116 B
(11B C
s11C D
.11D E
ContractorId11E Q
)11Q R
)11R S
;11S T
var33 
contractors33 
=33 
new33 
List33 "
<33" #
ContractorProfile33# 4
>334 5
(335 6
)336 7
;337 8
foreach55 
(55 
var55 
task55 
in55 
contractorTasks55 ,
)55, -
{66 	
contractors77 
.77 
Add77 
(77 
await77 !
task77" &
)77& '
;77' (
}88 	
var:: 

usersTasks:: 
=:: 
contractors:: $
.;; 
Select;; 
(;; 
c;; 
=>;; 
_userRepository;; (
.;;( )"
GetByContractorIdAsync;;) ?
(;;? @
c;;@ A
.;;A B
Id;;B D
);;D E
);;E F
;;;F G
var== 
users== 
=== 
new== 
List== 
<== 
User== !
>==! "
(==" #
)==# $
;==$ %
foreach?? 
(?? 
var?? 
task?? 
in?? 

usersTasks?? '
)??' (
{@@ 	
usersAA 
.AA 
AddAA 
(AA 
awaitAA 
taskAA  
)AA  !
;AA! "
}BB 	
returnDD 
ordersDD 
.EE 
SelectEE 
(EE 
(EE 
rEE 
,EE 
iEE 
)EE 
=>EE 
newEE !
UserOrderResponseEE" 3
(EE3 4
rFF 
.FF 
IdFF 
,FF 
rGG 
.GG 
DescriptionGG 
,GG 
rHH 
.HH 
PaymentAmountHH 
,HH  
rII 
.II 
	OrderDateII 
,II 
rJJ 
.JJ 
OrderStatusJJ 
.JJ 
ToStringJJ &
(JJ& '
)JJ' (
,JJ( )
usersKK 
[KK 
iKK 
]KK 
.KK 
GetDisplayNameKK '
(KK' (
)KK( )
,KK) *
servicesLL 
[LL 
iLL 
]LL 
.LL 
IdLL 
,LL 
servicesMM 
[MM 
iMM 
]MM 
.MM 
NameMM  
,MM  !
newNN 
ContactInfoResponseNN '
(NN' (
rOO 
.OO !
ContractorContactInfoOO +
.OO+ ,
TypeOO, 0
.OO0 1
ToStringOO1 9
(OO9 :
)OO: ;
,OO; <
rPP 
.PP !
ContractorContactInfoPP +
.PP+ ,
ValuePP, 1
)PP1 2
)PP2 3
)PP3 4
.QQ 
OrderByDescendingQQ 
(QQ 
rQQ  
=>QQ! #
rQQ$ %
.QQ% &
RequestDateQQ& 1
)QQ1 2
.RR 
ToListRR 
(RR 
)RR 
;RR 
}SS 
}TT À
äD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Queries\GetOrdersForUser\GetOrdersForUserQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Orders %
.% &
Queries& -
.- .
GetOrdersForUser. >
;> ?
public 
record !
GetOrdersForUserQuery #
(# $
Guid$ (
UserId) /
)/ 0
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" #
UserOrderResponse# 4
>4 5
>5 6
>6 7
;7 8Ì'
óD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Queries\GetOrdersForService\GetOrdersForServiceQueryHandler.cs
	namespace		 	
Dealoviy		
 
.		 
Application		 
.		 
Orders		 %
.		% &
Queries		& -
.		- .
GetOrdersForService		. A
;		A B
public 
class +
GetOrdersForServiceQueryHandler ,
: 
IRequestHandler 
< $
GetOrdersForServiceQuery .
,. /
ErrorOr 
< 
IEnumerable 
<  
ServiceOrderResponse 0
>0 1
>1 2
>2 3
{ 
private 
readonly 
IServiceRepository '
_serviceRepository( :
;: ;
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
public 
+
GetOrdersForServiceQueryHandler *
(* +
IServiceRepository 
serviceRepository ,
,, -
IOrderRepository 
orderRepository (
,( )
IUserRepository 
userRepository &
)& '
{ 
_serviceRepository 
= 
serviceRepository .
;. /
_orderRepository 
= 
orderRepository *
;* +
_userRepository 
= 
userRepository (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
< 
IEnumerable )
<) * 
ServiceOrderResponse* >
>> ?
>? @
>@ A
Handle 
( $
GetOrdersForServiceQuery '
request( /
,/ 0
CancellationToken 
cancellationToken /
)/ 0
{   
if!! 

(!! 
await!! 
_serviceRepository!! $
.!!$ %
GetByIdAsync!!% 1
(!!1 2
request!!2 9
.!!9 :
	ServiceId!!: C
)!!C D
is"" 
not"" 
{"" 
}"" 
service"" 
)"" 
{## 	
return$$ 
Errors$$ 
.$$ 
ServiceNotFound$$ )
;$$) *
}%% 	
var(( 
orders(( 
=(( 
await(( 
_orderRepository(( +
.((+ ,
GetByServiceIdAsync((, ?
(((? @
service((@ G
.((G H
Id((H J
)((J K
;((K L
var** 
customersTasks** 
=** 
orders** #
.++ 
Select++ 
(++ 
r++ 
=>++ 
_userRepository++ (
.++( )
GetUserByIdAsync++) 9
(++9 :
r++: ;
.++; <

CustomerId++< F
)++F G
)++G H
;++H I
var-- 
	customers-- 
=-- 
new-- 
List--  
<--  !
User--! %
>--% &
(--& '
)--' (
;--( )
foreach// 
(// 
var// 
task// 
in// 
customersTasks// +
)//+ ,
{00 	
	customers11 
.11 
Add11 
(11 
await11 
task11  $
)11$ %
;11% &
}22 	
return44 
orders44 
.55 
Select55 
(55 
(55 
o55 
,55 
i55 
)55 
=>55 
new55 ! 
ServiceOrderResponse55" 6
(556 7
o66 
.66 
Id66 
,66 
o77 
.77 
Description77 
,77 
o88 
.88 
PaymentAmount88 
,88  
o99 
.99 
	OrderDate99 
,99 
o:: 
.:: 
OrderStatus:: 
.:: 
ToString:: &
(::& '
)::' (
,::( )
	customers;; 
[;; 
i;; 
];; 
.;; 
GetDisplayName;; +
(;;+ ,
);;, -
,;;- .
new<< 
ContactInfoResponse<< '
(<<' (
o== 
.== 
CustomerContactInfo== )
.==) *
Type==* .
.==. /
ToString==/ 7
(==7 8
)==8 9
,==9 :
o>> 
.>> 
CustomerContactInfo>> )
.>>) *
Value>>* /
)>>/ 0
)?? 
)?? 
.@@ 
OrderByDescending@@ 
(@@ 
o@@  
=>@@! #
o@@$ %
.@@% &
RequestDate@@& 1
)@@1 2
.AA 
ToListAA 
(AA 
)AA 
;AA 
}BB 
}CC ›
êD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Queries\GetOrdersForService\GetOrdersForServiceQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Orders %
.% &
Queries& -
.- .
GetOrdersForService. A
;A B
public 
record $
GetOrdersForServiceQuery &
(& '
Guid' +
	ServiceId, 5
)5 6
: 
IRequest 
< 
ErrorOr 
< 
IEnumerable "
<" # 
ServiceOrderResponse# 7
>7 8
>8 9
>9 :
;: ;ˆ!
ëD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Commands\UpdateStatus\UpdateOrderStatusCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Orders %
.% &
Commands& .
.. /
UpdateStatus/ ;
;; <
public		 
class		 +
UpdateOrderStatusCommandHandler		 ,
:

 
IRequestHandler

 
<

 $
UpdateOrderStatusCommand

 .
,

. /
ErrorOr

0 7
<

7 8
Unit

8 <
>

< =
>

= >
{ 
private 
readonly 
IOrderRepository %
_orderRepository& 6
;6 7
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
public 
+
UpdateOrderStatusCommandHandler *
(* +
IOrderRepository 
orderRepository (
,( )
IUserRepository 
userRepository &
,& '(
IContractorProfileRepository $'
contractorProfileRepository% @
)@ A
{ 
_orderRepository 
= 
orderRepository *
;* +
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,$
UpdateOrderStatusCommand, D
requestE L
,L M
CancellationTokenN _
cancellationToken` q
)q r
{ 
if 

( 
await 
_orderRepository "
." #
GetByIdAsync# /
(/ 0
request0 7
.7 8
OrderId8 ?
)? @
is 
not 
Order 
order 
) 
{ 	
return 
Error 
. 
NotFound !
(! "
$str" 2
,2 3
$str4 I
)I J
;J K
}   	
if"" 

("" 
await"" 
_userRepository"" !
.""! "
GetUserByIdAsync""" 2
(""2 3
request""3 :
."": ;
UserContractorId""; K
)""K L
is## 
not## 
User## 

contractor## "
)##" #
{$$ 	
return%% 
Error%% 
.%% 
NotFound%% !
(%%! "
$str%%" 7
,%%7 8
$str%%9 S
)%%S T
;%%T U
}&& 	
if(( 

((( 

contractor(( 
.(( 
ContractorProfileId(( *
is((+ -
null((. 2
)((2 3
{)) 	
return** 
Error** 
.** 
Conflict** !
(**! "
$str**" 6
,**6 7
$str**8 R
)**R S
;**S T
}++ 	
if-- 

(-- 
await-- (
_contractorProfileRepository-- .
.--. /
GetByIdAsync--/ ;
(--; <

contractor--< F
.--F G
ContractorProfileId--G Z
.--Z [
Value--[ `
)--` a
is.. 
null.. 
).. 
{// 	
return00 
Error00 
.00 
NotFound00 !
(00! "
$str00" >
,00> ?
$str00@ b
)00b c
;00c d
}11 	
order33 
.33 
UpdateOrderStatus33 
(33  
request33  '
.33' (
Status33( .
)33. /
;33/ 0
await44 
_orderRepository44 
.44 
UpdateAsync44 *
(44* +
order44+ 0
)440 1
;441 2
return66 
Unit66 
.66 
Value66 
;66 
}77 
}88 É
äD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Orders\Commands\UpdateStatus\UpdateOrderStatusCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Orders %
.% &
Commands& .
.. /
UpdateStatus/ ;
;; <
public 
record $
UpdateOrderStatusCommand &
(& '
Guid' +
OrderId, 3
,3 4
Guid5 9
UserContractorId: J
,J K
OrderStatusL W
StatusX ^
)^ _
: 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; ¡
hD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\DependencyInjection.cs
	namespace 	
Dealoviy
 
. 
Application 
; 
public		 
static		 
class		 
DependencyInjection		 '
{

 
public 

static 
IServiceCollection $
AddApplication% 3
(3 4
this4 8
IServiceCollection9 K
servicesL T
)T U
{ 
services 
. 

AddMediatR 
( 
options #
=>$ &
{ 	
options 
. (
RegisterServicesFromAssembly 0
(0 1
Assembly1 9
.9 : 
GetExecutingAssembly: N
(N O
)O P
)P Q
;Q R
} 	
)	 

;
 
services 
. 
	AddScoped 
( 
typeof !
(! "
IPipelineBehavior" 3
<3 4
,4 5
>5 6
)6 7
,7 8
typeof9 ?
(? @
ValidationBehavior@ R
<R S
,S T
>T U
)U V
)V W
;W X
services 
. %
AddValidatorsFromAssembly *
(* +
Assembly+ 3
.3 4 
GetExecutingAssembly4 H
(H I
)I J
)J K
;K L
return 
services 
; 
} 
} “
éD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Queries\Common\ContractorProfileResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Queries2 9
.9 :
Common: @
;@ A
public 
record #
ContractorProfileResult %
(% &
Guid 
Id	 
, 
string 

Name 
, 
string 

AdditionalInfo 
, 
string 

[
 
] 
ContactTypes 
) 
; Ô
úD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Queries\GetById\GetContractorProfileByIdQueryHandler.cs
	namespace		 	
Dealoviy		
 
.		 
Application		 
.		 
ContractorProfiles		 1
.		1 2
Queries		2 9
.		9 :
GetById		: A
;		A B
public 
class 0
$GetContractorProfileByIdQueryHandler 1
: 
IRequestHandler 
< )
GetContractorProfileByIdQuery 3
,3 4
ErrorOr5 <
<< =#
ContractorProfileResult= T
>T U
>U V
{ 
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
public 
0
$GetContractorProfileByIdQueryHandler /
(/ 0
IUserRepository0 ?
userRepository@ N
,N O(
IContractorProfileRepositoryP l(
contractorProfileRepository	m à
)
à â
{ 
_userRepository 
= 
userRepository (
;( )(
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
} 
public 

async 
Task 
< 
ErrorOr 
< #
ContractorProfileResult 5
>5 6
>6 7
Handle8 >
(> ?)
GetContractorProfileByIdQuery %
request& -
,- .
CancellationToken 
cancellationToken +
)+ ,
{ 
if 

( 
await (
_contractorProfileRepository .
.. /
GetByIdAsync/ ;
(; <
request< C
.C D
IdD F
)F G
isH J
notK N
ContractorProfileO `
profilea h
)h i
{ 	
return 
Errors 
. %
ContractorProfileNotFound 3
;3 4
} 	
if   

(   
await   
_userRepository   !
.  ! ""
GetByContractorIdAsync  " 8
(  8 9
request  9 @
.  @ A
Id  A C
)  C D
is  E G
not  H K
User  L P
user  Q U
)  U V
{!! 	
return"" 
Errors"" 
."" 
UserNotFound"" &
;""& '
}## 	
return%% 
new%% #
ContractorProfileResult%% *
(%%* +
profile&& 
.&& 
Id&& 
,&& 
user'' 
.'' 
GetDisplayName'' 
(''  
)''  !
,''! "
profile(( 
.(( 
AdditionalInfo(( "
,((" #
profile)) 
.)) 
ContactInfos))  
.))  !
Select** 
(** 
ct** 
=>** 
ct** 
.**  
Type**  $
.**$ %
ToString**% -
(**- .
)**. /
)**/ 0
.**0 1
ToArray**1 8
(**8 9
)**9 :
)**: ;
;**; <
}++ 
},, ¨
ïD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Queries\GetById\GetContractorProfileByIdQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Queries2 9
.9 :
GetById: A
;A B
public 
record )
GetContractorProfileByIdQuery +
(+ ,
Guid, 0
Id1 3
)3 4
: 
IRequest 
< 
ErrorOr 
< #
ContractorProfileResult .
>. /
>/ 0
;0 1ø
üD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Update\UpdateContractorProfileCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Update; A
;A B
public 
class 3
'UpdateContractorProfileCommandValidator 4
: 1
%ContractorProfileCommandBaseValidator +
<+ ,*
UpdateContractorProfileCommand, J
>J K
{ 
public 
3
'UpdateContractorProfileCommandValidator 2
(2 3
)3 4
:5 6
base7 ;
(; <
)< =
{		 
}

 
} °!
ùD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Update\UpdateContractorProfileCommandHandler.cs
	namespace

 	
Dealoviy


 
.

 
Application

 
.

 
ContractorProfiles

 1
.

1 2
Commands

2 :
.

: ;
Update

; A
;

A B
public 
class 1
%UpdateContractorProfileCommandHandler 2
: 
IRequestHandler 
< *
UpdateContractorProfileCommand 4
,4 5
ErrorOr6 =
<= >
Unit> B
>B C
>C D
{ 
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IMapper 
_mapper $
;$ %
public 
1
%UpdateContractorProfileCommandHandler 0
(0 1(
IContractorProfileRepository $'
contractorProfileRepository% @
,@ A
IUserRepository 
userRepository &
,& '
IMapper 
mapper 
) 
{ (
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
_userRepository 
= 
userRepository (
;( )
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,*
UpdateContractorProfileCommand, J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 
if 

( 
await 
_userRepository !
.! "
GetUserByIdAsync" 2
(2 3
request3 :
.: ;
UserId; A
)A B
is   
not   
User   
user   
)   
{!! 	
return"" 
Errors"" 
."" 
UserNotFound"" &
;""& '
}## 	
if%% 

(%%
 
user%% 
.%% 
ContractorProfileId%% #
is%%$ &
null%%' +
||%%, .
await&& (
_contractorProfileRepository&& .
.&&. /
GetByIdAsync&&/ ;
(&&; <
user&&< @
.&&@ A
ContractorProfileId&&A T
.&&T U
Value&&U Z
)&&Z [
is'' 
not'' 
ContractorProfile'' $
profile''% ,
)'', -
{(( 	
return)) 
Errors)) 
.)) %
ContractorProfileNotFound)) 3
;))3 4
}** 	
var,, #
contractorProfileResult,, #
=,,$ %
profile,,& -
.,,- .
Update,,. 4
(,,4 5
request-- 
.-- 
AdditionalInfo-- "
,--" #
_mapper.. 
... 
Map.. 
<.. 
List.. 
<.. "
ContactInfoCreateModel.. 3
>..3 4
>..4 5
(..5 6
request..6 =
...= >
ContactInfos..> J
)..J K
)// 	
;//	 

if11 

(11 #
contractorProfileResult11 #
.11# $
IsError11$ +
)11+ ,
{22 	
return33 #
contractorProfileResult33 *
.33* +
Errors33+ 1
;331 2
}44 	
var66 
contractorProfile66 
=66 #
contractorProfileResult66  7
.667 8
Value668 =
;66= >
await88 (
_contractorProfileRepository88 *
.88* +
UpdateAsync88+ 6
(886 7
contractorProfile887 H
)88H I
;88I J
return:: 
Unit:: 
.:: 
Value:: 
;:: 
};; 
}<< â
ñD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Update\UpdateContractorProfileCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Update; A
;A B
public 
record *
UpdateContractorProfileCommand ,
(, -
Guid		 
UserId			 
,		 
string

 

AdditionalInfo

 
,

 
List 
< 	
ContactInfoModel	 
> 
ContactInfos '
) 
: %
IContractorProfileCommand 
, 
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; ø
üD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Create\CreateContractorProfileCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Create; A
;A B
public 
class 3
'CreateContractorProfileCommandValidator 4
:5 61
%ContractorProfileCommandBaseValidator )
<) **
CreateContractorProfileCommand* H
>H I
{ 
public 
3
'CreateContractorProfileCommandValidator 2
(2 3
)3 4
:5 6
base7 ;
(; <
)< =
{		 
}

 
} Ö
ùD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Create\CreateContractorProfileCommandHandler.cs
	namespace

 	
Dealoviy


 
.

 
Application

 
.

 
ContractorProfiles

 1
.

1 2
Commands

2 :
.

: ;
Create

; A
;

A B
public 
class 1
%CreateContractorProfileCommandHandler 2
:3 4
IRequestHandler5 D
<D E*
CreateContractorProfileCommandE c
,c d
ErrorOre l
<l m
Unitm q
>q r
>r s
{ 
private 
readonly (
IContractorProfileRepository 1(
_contractorProfileRepository2 N
;N O
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IMapper 
_mapper $
;$ %
public 
1
%CreateContractorProfileCommandHandler 0
(0 1(
IContractorProfileRepository $'
contractorProfileRepository% @
,@ A
IUserRepository 
userRepository &
,& '
IMapper 
mapper 
) 
{ (
_contractorProfileRepository $
=% &'
contractorProfileRepository' B
;B C
_userRepository 
= 
userRepository (
;( )
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
ErrorOr 
< 
Unit "
>" #
># $
Handle% +
(+ ,*
CreateContractorProfileCommand, J
requestK R
,R S
CancellationTokenT e
cancellationTokenf w
)w x
{ 
if 

( 
await 
_userRepository !
.! "
GetUserByIdAsync" 2
(2 3
request3 :
.: ;
UserId; A
)A B
is 
not 
User 
user 
) 
{   	
return!! 
Errors!! 
.!! 
UserNotFound!! &
;!!& '
}"" 	
var$$ #
contractorProfileResult$$ #
=$$$ %
ContractorProfile$$& 7
.$$7 8
Create$$8 >
($$> ?
request%% 
.%% 
AdditionalInfo%% "
,%%" #
_mapper&& 
.&& 
Map&& 
<&& 
List&& 
<&& "
ContactInfoCreateModel&& 3
>&&3 4
>&&4 5
(&&5 6
request&&6 =
.&&= >
ContactInfos&&> J
)&&J K
)'' 	
;''	 

if)) 

()) #
contractorProfileResult)) #
.))# $
IsError))$ +
)))+ ,
{** 	
return++ #
contractorProfileResult++ *
.++* +
Errors+++ 1
;++1 2
},, 	
var.. 
contractorProfile.. 
=.. #
contractorProfileResult..  7
...7 8
Value..8 =
;..= >
await00 (
_contractorProfileRepository00 *
.00* +
AddAsync00+ 3
(003 4
contractorProfile004 E
)00E F
;00F G
user22 
.22 "
SetContractorProfileId22 #
(22# $
contractorProfile22$ 5
.225 6
Id226 8
)228 9
;229 :
await33 
_userRepository33 
.33 
UpdateAsync33 )
(33) *
user33* .
)33. /
;33/ 0
return55 
Unit55 
.55 
Value55 
;55 
}66 
}77 ã
ñD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Create\CreateContractorProfileCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Create; A
;A B
public 
record *
CreateContractorProfileCommand ,
(, -
Guid		 
UserId			 
,		 
string

 

AdditionalInfo

 
,

 
List 
< 	
ContactInfoModel	 
> 
ContactInfos '
) 
: %
IContractorProfileCommand !
,! "
IRequest 
< 
ErrorOr 
< 
Unit 
> 
> 
; π
®D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Common\Validators\ContractorProfileCommandBaseValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Common; A
.A B

ValidatorsB L
;L M
public 
abstract 
class 1
%ContractorProfileCommandBaseValidator ;
<; <%
TContractorProfileCommand< U
>U V
: 
AbstractValidator 
< %
TContractorProfileCommand 1
>1 2
where		 	%
TContractorProfileCommand		
 #
:		$ %%
IContractorProfileCommand		& ?
{

 
	protected 1
%ContractorProfileCommandBaseValidator 3
(3 4
)4 5
{ 
RuleFor 
( 
x 
=> 
x 
. 
AdditionalInfo %
)% &
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str ?
)? @
. 
WithMessage 
( 
$str 6
)6 7
;7 8
RuleFor 
( 
x 
=> 
x 
. 
ContactInfos #
)# $
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str =
)= >
. 
WithMessage 
( 
$str 5
)5 6
;6 7
RuleForEach 
( 
x 
=> 
x 
. 
ContactInfos '
)' (
. 
SetValidator 
( 
new %
ContactInfoModelValidator 7
(7 8
)8 9
)9 :
;: ;
} 
} Å
úD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\ContractorProfiles\Commands\Common\Interfaces\IContractorProfileCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
ContractorProfiles 1
.1 2
Commands2 :
.: ;
Common; A
.A B

InterfacesB L
;L M
public 
	interface %
IContractorProfileCommand *
{ 
Guid 
UserId	 
{ 
get 
; 
} 
string 

AdditionalInfo 
{ 
get 
;  
}! "
List		 
<		 	
ContactInfoModel			 
>		 
ContactInfos		 '
{		( )
get		* -
;		- .
}		/ 0
}

 õ
ÄD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Validators\ContactInfoModelValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Validators& 0
;0 1
public 
class %
ContactInfoModelValidator &
:' (
AbstractValidator) :
<: ;
ContactInfoModel; K
>K L
{ 
public 
%
ContactInfoModelValidator $
($ %
)% &
{		 
RuleFor 
( 
x 
=> 
x 
. 
Value 
) 
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str ?
)? @
. 
WithMessage 
( 
$str =
)= >
;> ?
RuleFor 
( 
x 
=> 
x 
. 
Value 
) 
. 
MaximumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str A
)A B
. 
WithMessage 
( 
$str R
)R S
;S T
} 
} Í
sD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Models\ContactInfoModel.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
Models& ,
;, -
public 
record 
ContactInfoModel 
( 
string 

Type 
, 
string 

Value 
) 
; ∫
yD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Mappings\ServiceMappingConfig.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
Mappings& .
;. /
public 
class  
ServiceMappingConfig !
:" #
	IRegister$ -
{ 
public		 

void		 
Register		 
(		 
TypeAdapterConfig		 *
config		+ 1
)		1 2
{

 
config 
. 
	NewConfig 
< 
( 
Service !
service" )
,) *
string+ 1
CityName2 :
): ;
,; <
ServiceResult= J
>J K
(K L
)L M
. 
Map 
( 
dest 
=> 
dest 
. 
	ServiceId '
,' (
src) ,
=>- /
src0 3
.3 4
service4 ;
.; <
Id< >
)> ?
. 
Map 
( 
dest 
=> 
dest 
. 
ContractorId *
,* +
src, /
=>0 2
src3 6
.6 7
service7 >
.> ?
ContractorId? K
)K L
. 
Map 
( 
dest 
=> 
dest 
. 
Name "
," #
src$ '
=>( *
src+ .
.. /
service/ 6
.6 7
Name7 ;
); <
. 
Map 
( 
dest 
=> 
dest 
. 
CityName &
,& '
src( +
=>, .
src/ 2
.2 3
CityName3 ;
); <
. 
Map 
( 
dest 
=> 
dest 
. 
Description )
,) *
src+ .
=>/ 1
src2 5
.5 6
service6 =
.= >
Description> I
)I J
. 
Map 
( 
dest 
=> 
dest 
. 
LowerPriceBound -
,- .
src/ 2
=>3 5
src6 9
.9 :
service: A
.A B

PriceRangeB L
.L M
LowerM R
)R S
. 
Map 
( 
dest 
=> 
dest 
. 
UpperPriceBound -
,- .
src/ 2
=>3 5
src6 9
.9 :
service: A
.A B

PriceRangeB L
.L M
UpperM R
)R S
. 
Map 
( 
dest 
=> 
dest 
. 
AverageRating +
,+ ,
src- 0
=>1 3
src4 7
.7 8
service8 ?
.? @
AverageRating@ M
.M N
ValueN S
)S T
. 
Map 
( 
dest 
=> 
dest 
. 
ReviewsCount *
,* +
src, /
=>0 2
src3 6
.6 7
service7 >
.> ?
AverageRating? L
.L M
CountM R
)R S
;S T
} 
} ó
xD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Mappings\RegionMappingConfig.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
Mappings& .
;. /
public 
class 
RegionMappingConfig  
:! "
	IRegister# ,
{ 
public		 

void		 
Register		 
(		 
TypeAdapterConfig		 *
config		+ 1
)		1 2
{

 
config 
. 
	NewConfig 
< 
Region 
,  
RegionResult! -
>- .
(. /
)/ 0
;0 1
} 
} µ
}D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Mappings\ContactInfoMappingConfig.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
Mappings& .
;. /
public 
class $
ContactInfoMappingConfig %
:& '
	IRegister( 1
{ 
public		 

void		 
Register		 
(		 
TypeAdapterConfig		 *
config		+ 1
)		1 2
{

 
config 
. 
	NewConfig 
< 
ContactInfoModel )
,) *"
ContactInfoCreateModel+ A
>A B
(B C
)C D
;D E
} 
} è
vD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Mappings\CityMappingConfig.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
Mappings& .
;. /
public 
class 
CityMappingConfig 
:  
	IRegister! *
{ 
public		 

void		 
Register		 
(		 
TypeAdapterConfig		 *
config		+ 1
)		1 2
{

 
config 
. 
	NewConfig 
< 
City 
, 

CityResult )
>) *
(* +
)+ ,
;, -
} 
} ü
ÅD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Services\IDateTimeProvider.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Services1 9
;9 :
public 
	interface 
IDateTimeProvider "
{ 
DateTime 
UtcNow 
{ 
get 
; 
} 
} ˚
D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Security\IPasswordHasher.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Security1 9
;9 :
public 
	interface 
IPasswordHasher  
{ 
string 

HashPassword 
( 
string 
password '
)' (
;( )
bool 
VerifyPassword	 
( 
string 
hashedPassword -
,- .
string/ 5
password6 >
)> ?
;? @
} Ü

ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IUserRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IUserRepository  
{ 
Task 
< 	
User	 
? 
> 
GetUserByIdAsync  
(  !
Guid! %
id& (
)( )
;) *
Task 
< 	
User	 
? 
> "
GetUserByUsernameAsync &
(& '
string' -
username. 6
)6 7
;7 8
Task		 
<		 	
User			 
?		 
>		 "
GetByContractorIdAsync		 &
(		& '
Guid		' +
contractorId		, 8
)		8 9
;		9 :
Task

 
AddAsync

	 
(

 
User

 
user

 
)

 
;

 
Task 
UpdateAsync	 
( 
User 
user 
) 
;  
} £
ÖD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IServiceRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IServiceRepository #
{ 
Task 
< 	
Service	 
? 
> 
GetByIdAsync 
(  
Guid  $
id% '
)' (
;( )
Task 
AddAsync	 
( 
Service 
service !
)! "
;" #
Task		 
UpdateAsync			 
(		 
Service		 
service		 $
)		$ %
;		% &
Task

 
<

 	
IEnumerable

	 
<

 
Service

 
>

 
>

 $
GetByKeywordAndCityAsync

 7
(

7 8
string

8 >
keyword

? F
,

F G
Guid

H L
cityId

M S
)

S T
;

T U
Task 
< 	
IEnumerable	 
< 
Service 
> 
> "
GetByContractorIdAsync 5
(5 6
Guid6 :
contractorId; G
)G H
;H I
} Ø
ÑD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IReviewRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IReviewRepository "
{ 
Task 
	AddReview	 
( 
Review 
review  
)  !
;! "
Task 
< 	
IEnumerable	 
< 
Review 
> 
> !
GetReviewsByServiceId 3
(3 4
Guid4 8
	serviceId9 B
)B C
;C D
}		 Ó
ÖD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IRequestRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IRequestRepository #
{ 
Task 
AddAsync	 
( 
Request 
request !
)! "
;" #
Task 
< 	
IEnumerable	 
< 
Request 
> 
> 
GetByServiceIdAsync 2
(2 3
Guid3 7
	serviceId8 A
)A B
;B C
Task		 
<		 	
IEnumerable			 
<		 
Request		 
>		 
>		  
GetByCustomerIdAsync		 3
(		3 4
Guid		4 8

customerId		9 C
)		C D
;		D E
Task 
< 	
Request	 
? 
> 
GetByIdAsync 
(  
Guid  $
	requestId% .
). /
;/ 0
Task 
UpdateAsync	 
( 
Request 
request $
)$ %
;% &
Task 
DeleteAsync	 
( 
Request 
request $
)$ %
;% &
} «
ÑD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IRegionRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IRegionRepository "
{ 
Task 
< 	
IEnumerable	 
< 
Region 
> 
> 
GetAllRegionsAsync 0
(0 1
)1 2
;2 3
Task 
< 	
Region	 
? 
> 
GetRegionByIdAsync $
($ %
Guid% )
id* ,
), -
;- .
}		 ﬁ

ÉD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IOrderRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
IOrderRepository !
{ 
Task 
AddAsync	 
( 
Order 
request 
)  
;  !
Task 
< 	
IEnumerable	 
< 
Order 
> 
> 
GetByServiceIdAsync 0
(0 1
Guid1 5
	serviceId6 ?
)? @
;@ A
Task		 
<		 	
IEnumerable			 
<		 
Order		 
>		 
>		  
GetByCustomerIdAsync		 1
(		1 2
Guid		2 6

customerId		7 A
)		A B
;		B C
Task 
< 	
Order	 
? 
> 
GetByIdAsync 
( 
Guid "
	requestId# ,
), -
;- .
Task 
UpdateAsync	 
( 
Order 
request "
)" #
;# $
} Ø
èD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\IContractorProfileRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface (
IContractorProfileRepository -
{ 
Task 
< 	
ContractorProfile	 
? 
> 
GetByIdAsync )
() *
Guid* .
id/ 1
)1 2
;2 3
Task 
AddAsync	 
( 
ContractorProfile #
profile$ +
)+ ,
;, -
Task		 
UpdateAsync			 
(		 
ContractorProfile		 &
profile		' .
)		. /
;		/ 0
}

 Î
ÇD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Persistence\ICityRepository.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Persistence1 <
;< =
public 
	interface 
ICityRepository  
{ 
Task 
< 	
IEnumerable	 
< 
City 
> 
> $
GetCitiesByRegionIdAsync 4
(4 5
Guid5 9
regionId: B
)B C
;C D
Task 
< 	
City	 
? 
> 
GetCityByIdAsync  
(  !
Guid! %
id& (
)( )
;) *
}		 ≈
àD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Interfaces\Authentication\IJwtTokenGenerator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &

Interfaces& 0
.0 1
Authentication1 ?
;? @
public 
	interface 
IJwtTokenGenerator #
{ 
string 

GenerateToken 
( 
User 
user "
)" #
;# $
} Ù
xD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Common\Behaviors\ValidationBehavior.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Common %
.% &
	Behaviors& /
;/ 0
public 
class 
ValidationBehavior 
<  
TRequest  (
,( )
	TResponse* 3
>3 4
:5 6
IPipelineBehavior 
< 
TRequest 
, 
	TResponse  )
>) *
where		 	
TRequest		
 
:		 
IRequest		 
<		 
	TResponse		 '
>		' (
where

 	
	TResponse


 
:

 
IErrorOr

 
{ 
private 
readonly 

IValidator 
<  
TRequest  (
>( )
?) *

_validator+ 5
;5 6
public 

ValidationBehavior 
( 

IValidator (
<( )
TRequest) 1
>1 2
?2 3
	validator4 =
=> ?
null@ D
)D E
{ 

_validator 
= 
	validator 
; 
} 
public 

async 
Task 
< 
	TResponse 
>  
Handle! '
(' (
TRequest 
request 
, "
RequestHandlerDelegate 
< 
	TResponse (
>( )
next* .
,. /
CancellationToken 
cancellationToken +
)+ ,
{ 
if 

( 

_validator 
is 
null 
) 
{ 	
return 
await 
next 
( 
) 
;  
} 	
var 
validationResult 
= 
await $

_validator% /
./ 0
ValidateAsync0 =
(= >
request> E
,E F
cancellationTokenG X
)X Y
;Y Z
if 

( 
validationResult 
. 
IsValid $
)$ %
{ 	
return   
await   
next   
(   
)   
;    
}!! 	
var## 
errors## 
=## 
validationResult## %
.##% &
Errors##& ,
.$$ 
Select$$ 
($$ 
e$$ 
=>$$ 
Error$$ 
.$$ 

Validation$$ )
($$) *
code%% 
:%% 
e%% 
.%% 
	ErrorCode%% !
,%%! "
description&& 
:&& 
e&& 
.&& 
ErrorMessage&& +
)&&+ ,
)&&, -
.'' 
ToList'' 
('' 
)'' 
;'' 
return)) 
()) 
dynamic)) 
))) 
errors)) 
;)) 
}** 
}++ ˙
ìD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Cities\Queries\GetCitiesInRegion\GetCitiesInRegionQueryHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Cities %
.% &
Queries& -
.- .
GetCitiesInRegion. ?
;? @
public 
class )
GetCitiesInRegionQueryHandler *
:+ ,
IRequestHandler- <
<< ="
GetCitiesInRegionQuery= S
,S T
IEnumerableU `
<` a

CityResulta k
>k l
>l m
{		 
private

 
readonly

 
ICityRepository

 $
_cityRepository

% 4
;

4 5
private 
readonly 
IMapper 
_mapper $
;$ %
public 
)
GetCitiesInRegionQueryHandler (
(( )
ICityRepository 
cityRepository &
,& '
IMapper 
mapper 
) 
{ 
_cityRepository 
= 
cityRepository (
;( )
_mapper 
= 
mapper 
; 
} 
public 

async 
Task 
< 
IEnumerable !
<! "

CityResult" ,
>, -
>- .
Handle/ 5
(5 6"
GetCitiesInRegionQuery6 L
requestM T
,T U
CancellationTokenV g
cancellationTokenh y
)y z
{ 
var 
regions 
= 
await 
_cityRepository +
.+ ,$
GetCitiesByRegionIdAsync, D
(D E
requestE L
.L M
RegionIdM U
)U V
;V W
return 
_mapper 
. 
Map 
< 
IEnumerable &
<& '

CityResult' 1
>1 2
>2 3
(3 4
regions4 ;
); <
;< =
} 
} ó
åD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Cities\Queries\GetCitiesInRegion\GetCitiesInRegionQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Cities %
.% &
Queries& -
.- .
GetCitiesInRegion. ?
;? @
public 
record "
GetCitiesInRegionQuery $
($ %
Guid% )
RegionId* 2
)2 3
: 
IRequest 
< 
IEnumerable 
< 

CityResult %
>% &
>& '
;' (Ÿ
mD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Cities\Common\CityResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Cities %
.% &
Common& ,
;, -
public 
record 

CityResult 
( 
Guid 
Id	 
, 
string 

Name 
) 
; ¶
ÉD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Queries\Login\LoginQueryHandler.cs
	namespace

 	
Dealoviy


 
.

 
Application

 
.

 
Authentication

 -
.

- .
Queries

. 5
.

5 6
Login

6 ;
;

; <
public 
class 
LoginQueryHandler 
:  
IRequestHandler! 0
<0 1

LoginQuery1 ;
,; <
ErrorOr= D
<D E 
AuthenticationResultE Y
>Y Z
>Z [
{ 
private 
readonly 
IJwtTokenGenerator '
_jwtTokenGenerator( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IPasswordHasher $
_passwordHasher% 4
;4 5
public 

LoginQueryHandler 
( 
IJwtTokenGenerator 
jwtTokenGenerator ,
,, -
IUserRepository 
userRepository &
,& '
IPasswordHasher 
passwordHasher &
)& '
{ 
_jwtTokenGenerator 
= 
jwtTokenGenerator .
;. /
_userRepository 
= 
userRepository (
;( )
_passwordHasher 
= 
passwordHasher (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
<  
AuthenticationResult 2
>2 3
>3 4
Handle5 ;
(; <

LoginQuery< F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 
if 

( 
await 
_userRepository !
.! ""
GetUserByUsernameAsync" 8
(8 9
request9 @
.@ A
UsernameA I
)I J
isK M
notN Q
UserR V
userW [
)[ \
{ 	
return   
Errors   
.   
InvalidCredentials   ,
;  , -
}!! 	
if## 

(##
 
!## 
_passwordHasher## 
.## 
VerifyPassword## *
(##* +
user##+ /
.##/ 0
PasswordHash##0 <
,##< =
request##> E
.##E F
Password##F N
)##N O
)##O P
{$$ 	
return%% 
Errors%% 
.%% 
InvalidCredentials%% ,
;%%, -
}&& 	
var(( 
token(( 
=(( 
_jwtTokenGenerator(( &
.((& '
GenerateToken((' 4
(((4 5
user((5 9
)((9 :
;((: ;
var** 
contractorProfileId** 
=**  !
user**" &
.**& '
ContractorProfileId**' :
is**; =
null**> B
?++ 
null++ 
:,, 
user,, 
.,, 
ContractorProfileId,, &
.,,& '
ToString,,' /
(,,/ 0
),,0 1
;,,1 2
return.. 
new..  
AuthenticationResult.. '
(..' (
user// 
.// 
Id// 
,// 
user00 
.00 
Username00 
,00 
user11 
.11 
DisplayName11 
,11 
contractorProfileId22 
,22  
token33 
)33 
;33 
}44 
}55 ∑
|D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Queries\Login\LoginQuery.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Authentication -
.- .
Queries. 5
.5 6
Login6 ;
;; <
public 
record 

LoginQuery 
( 
string		 

Username		 
,		 
string

 

Password

 
)

 
:

 
IRequest

 
<

  
ErrorOr

  '
<

' ( 
AuthenticationResult

( <
>

< =
>

= >
;

> ?’
D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Common\AuthenticationResult.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Authentication -
.- .
Common. 4
;4 5
public 
record  
AuthenticationResult "
(" #
Guid 
Id	 
, 
string 

Username 
, 
string 

?
 
DisplayName 
, 
string 

?
 
ContractorProfileId 
,  
string 

Token 
) 
; «
éD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Commands\Register\RegisterCommandValidator.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Authentication -
.- .
Commands. 6
.6 7
Register7 ?
;? @
public 
class $
RegisterCommandValidator %
:& '
AbstractValidator( 9
<9 :
RegisterCommand: I
>I J
{ 
public 
$
RegisterCommandValidator #
(# $
)$ %
{ 
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
Username		 
)		  
.

 
NotEmpty

 
(

 
)

 
. 
WithErrorCode 
( 
$str 6
)6 7
. 
WithMessage 
( 
$str 3
)3 4
;4 5
RuleFor 
( 
x 
=> 
x 
. 
Username 
)  
. 
MaximumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str 9
)9 :
. 
WithMessage 
( 
$str I
)I J
;J K
RuleFor 
( 
x 
=> 
x 
. 
DisplayName "
)" #
. 
MaximumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str ;
); <
. 
WithMessage 
( 
$str K
)K L
;L M
RuleFor 
( 
x 
=> 
x 
. 
Password 
)  
. 
NotEmpty 
( 
) 
. 
WithErrorCode 
( 
$str 6
)6 7
. 
WithMessage 
( 
$str 3
)3 4
;4 5
RuleFor 
( 
x 
=> 
x 
. 
Password 
)  
. 
MinimumLength 
( 
$num 
) 
. 
WithErrorCode 
( 
$str 9
)9 :
.   
WithMessage   
(   
$str   G
)  G H
;  H I
RuleFor"" 
("" 
x"" 
=>"" 
x"" 
."" 
Password"" 
)""  
.## 
MaximumLength## 
(## 
$num## 
)## 
.$$ 
WithErrorCode$$ 
($$ 
$str$$ 8
)$$8 9
.%% 
WithMessage%% 
(%% 
$str%% G
)%%G H
;%%H I
}&& 
}'' À
åD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Commands\Register\RegisterCommandHandler.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Authentication -
.- .
Commands. 6
.6 7
Register7 ?
;? @
public 
class "
RegisterCommandHandler #
: 
IRequestHandler 
< 
RegisterCommand %
,% &
ErrorOr' .
<. / 
AuthenticationResult/ C
>C D
>D E
{ 
private 
readonly 
IJwtTokenGenerator '
_jwtTokenGenerator( :
;: ;
private 
readonly 
IUserRepository $
_userRepository% 4
;4 5
private 
readonly 
IPasswordHasher $
_passwordHasher% 4
;4 5
public 
"
RegisterCommandHandler !
(! "
IJwtTokenGenerator 
jwtTokenGenerator ,
,, -
IUserRepository 
userRepository &
,& '
IPasswordHasher 
passwordHasher &
)& '
{ 
_jwtTokenGenerator 
= 
jwtTokenGenerator .
;. /
_userRepository 
= 
userRepository (
;( )
_passwordHasher 
= 
passwordHasher (
;( )
} 
public 

async 
Task 
< 
ErrorOr 
<  
AuthenticationResult 2
>2 3
>3 4
Handle5 ;
(; <
RegisterCommand< K
requestL S
,S T
CancellationTokenU f
cancellationTokeng x
)x y
{ 
if!! 

(!! 
await!! 
_userRepository!! !
.!!! ""
GetUserByUsernameAsync!!" 8
(!!8 9
request!!9 @
.!!@ A
Username!!A I
)!!I J
is!!K M
not!!N Q
null!!R V
)!!V W
{"" 	
return## 
Errors## 
.## 
DuplicateUsername## +
;##+ ,
}$$ 	
var&& 
hashedPassword&& 
=&& 
_passwordHasher&& ,
.&&, -
HashPassword&&- 9
(&&9 :
request&&: A
.&&A B
Password&&B J
)&&J K
;&&K L
var(( 
user(( 
=(( 
User(( 
.(( 
Create(( 
((( 
request)) 
.)) 
Username)) 
,)) 
request** 
.** 
DisplayName** 
,**  
hashedPassword++ 
)++ 
;++ 
await.. 
_userRepository.. 
... 
AddAsync.. &
(..& '
user..' +
)..+ ,
;.., -
var00 
token00 
=00 
_jwtTokenGenerator00 &
.00& '
GenerateToken00' 4
(004 5
user005 9
)009 :
;00: ;
var22 
contractorProfileId22 
=22  !
user22" &
.22& '
ContractorProfileId22' :
is22; =
null22> B
?33 
null33 
:44 
user44 
.44 
ContractorProfileId44 &
.44& '
ToString44' /
(44/ 0
)440 1
;441 2
return66 
new66  
AuthenticationResult66 '
(66' (
user77 
.77 
Id77 
,77 
user88 
.88 
Username88 
,88 
user99 
.99 
DisplayName99 
,99 
contractorProfileId:: 
,::  
token;; 
);; 
;;; 
}<< 
}== ì
ÖD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Application\Authentication\Commands\Register\RegisterCommand.cs
	namespace 	
Dealoviy
 
. 
Application 
. 
Authentication -
.- .
Commands. 6
.6 7
Register7 ?
;? @
public 
record 
RegisterCommand 
( 
string 

Username 
, 
string		 

?		
 
DisplayName		 
,		 
string

 

Password

 
) 
: 
IRequest 
< 
ErrorOr 
<  
AuthenticationResult )
>) *
>* +
;+ ,