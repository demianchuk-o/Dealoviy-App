�
eD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Users\UserResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Users "
;" #
public 
record 
UserResponse 
( 
Guid 
UserId	 
, 
string 

Username 
, 
string 

?
 
DisplayName 
, 
Guid 
? 	
ContractorProfileId
 
) 
; �
pD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Services\UpdateServiceRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Services %
;% &
public 
record  
UpdateServiceRequest "
(" #
Guid 
CityId	 
, 
string 

Name 
, 
string 

Description 
, 
int 
LowerPriceBound 
, 
int 
UpperPriceBound 
) 
; �
jD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Users\UpdateUserRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Users "
;" #
public 
record 
UpdateUserRequest 
(  
string 

DisplayName 
) 
; �
qD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Services\ServiceSearchResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Services %
;% &
public 
record !
ServiceSearchResponse #
(# $
IEnumerable 
< 
ServiceResponse 
>  
Services! )
,) *
int 

TotalCount 
, 
string 

Keyword 
, 
string 

CityName 
) 
; �
sD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Services\ServiceTaskStatResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Services %
;% &
public 
record #
ServiceTaskStatResponse %
(% &
Guid 
	ServiceId	 
, 
string 

ServiceName 
, 
int  
PendingRequestsCount 
, 
int "
NotFinishedOrdersCount 
) 
; �
kD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Services\ServiceResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Services %
;% &
public 
record 
ServiceResponse 
( 
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
; �
pD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Services\CreateServiceRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Services %
;% &
public 
record  
CreateServiceRequest "
(" #
Guid 
CityId	 
, 
string 

Name 
, 
string 

Description 
, 
int 
LowerPriceBound 
, 
int 
UpperPriceBound 
) 
; �
iD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Reviews\ReviewResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Reviews $
;$ %
public 
record 
ReviewResponse 
( 
Guid 
ReviewId	 
, 
string 

ReviewerName 
, 
string 


ReviewText 
, 
DateTime 

ReviewDate 
, 
int 
Rating 
)		 
;		 �
nD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Reviews\CreateReviewRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Reviews $
;$ %
public 
record 
CreateReviewRequest !
(! "
string 


ReviewText 
, 
int 
Rating 
) 
; �
oD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Requests\UserRequestResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Requests %
;% &
public 
record 
UserRequestResponse !
(! "
Guid 
	RequestId	 
, 
string 

Description 
, 
int 
PaymentAmount 
, 
DateTime		 
RequestDate		 
,		 
string

 

RequestStatus

 
,

 
string 

ContractorName 
, 
Guid 
	ServiceId	 
, 
string 

ServiceName 
, 
ContactInfoResponse !
ContractorContactInfo -
) 
; �
rD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Requests\ServiceRequestResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Requests %
;% &
public 
record "
ServiceRequestResponse $
($ %
Guid 
	RequestId	 
, 
string 

Description 
, 
int 
PaymentAmount 
, 
DateTime		 
RequestDate		 
,		 
string

 

RequestStatus

 
,

 
string 

CustomerName 
, 
ContactInfoResponse 
CustomerContactInfo +
) 
; �
pD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Requests\CreateRequestRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Requests %
;% &
public 
record  
CreateRequestRequest "
(" #
string 

Description 
, 
ContactInfoRequest 
CustomerContactInfo *
,* +
int 
PaymentAmount 
) 
; �
iD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Regions\RegionResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Regions $
;$ %
public 
record 
RegionResponse 
( 
Guid 
Id	 
, 
string 

Name 
) 
; �
kD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Orders\UserOrderResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Orders #
;# $
public 
record 
UserOrderResponse 
(  
Guid  $
	RequestId% .
,. /
string 

Description 
, 
int 
PaymentAmount 
, 
DateTime 
RequestDate 
, 
string		 

OrderStatus		 
,		 
string

 

ContractorName

 
,

 
Guid 
	ServiceId	 
, 
string 

ServiceName 
, 
ContactInfoResponse !
ContractorContactInfo -
) 
; �
nD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Orders\ServiceOrderResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Orders #
;# $
public 
record  
ServiceOrderResponse "
(" #
Guid 
OrderId	 
, 
string 

Description 
, 
int 
PaymentAmount 
, 
DateTime		 
RequestDate		 
,		 
string

 

OrderStatus

 
,

 
string 

CustomerName 
, 
ContactInfoResponse 
CustomerContactInfo +
) 
; �
zD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\ContractProfiles\ContractProfileRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
ContractProfiles -
;- .
public 
record "
ContractProfileRequest $
($ %
string 

AdditionalInfo 
, 
List 
< 	
ContactInfoRequest	 
> 
ContactInfos )
) 
; �
}D:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\ContractProfiles\ContractorProfileResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
ContractProfiles -
;- .
public 
record %
ContractorProfileResponse '
(' (
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
) 
; �
mD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Common\ContactInfoResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Common #
;# $
public 
record 
ContactInfoResponse !
(! "
string 

Type 
, 
string 

Value 
) 
; �
lD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Common\ContactInfoRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Common #
;# $
public 
record 
ContactInfoRequest  
(  !
string 

Type 
, 
string 

Value 
) 
; �
nD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Authentication\LoginRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Authentication +
;+ ,
public 
record 
LoginRequest 
( 
string 

Username 
, 
string 

Password 
) 
; �
fD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Cities\CityResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Cities #
;# $
public 
record 
CityResponse 
( 
Guid 
Id	 
, 
string 

Name 
) 
; �
qD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Authentication\RegisterRequest.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Authentication +
;+ ,
public 
record 
RegisterRequest 
( 
string 

Username 
, 
string 

?
 
DisplayName 
, 
string 

Password 
) 
; �
xD:\KPI\Labs_5sem\Dealovyi\pa-demyanchuk-ole\backend\Dealoviy\Dealoviy.Contracts\Authentication\AuthenticationResponse.cs
	namespace 	
Dealoviy
 
. 
	Contracts 
. 
Authentication +
;+ ,
public 
record "
AuthenticationResponse $
($ %
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
; 