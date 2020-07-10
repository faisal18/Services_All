USE [PBMLink.NET]
select top 1
(select COUNT(*) from [Transaction] with(nolock) where Status = 3) as 'PBMLink_Pending_Count',
(select COUNT(*) from [Transaction] with(nolock) where Status != 3 
and convert(date,dateordered) = convert(date,getdate())) as 'PBMLink_Processed_Count',
(select Count(*) from [transaction] with(nolock) where Status !=3
and [Plan] in (select ID from [Plan] where Payer not in(22))
and convert(date,dateordered) = convert(date,getdate()) ) as 'PBMLink_PBM_Payer_Processed_Count'
from [Transaction] with(nolock)
