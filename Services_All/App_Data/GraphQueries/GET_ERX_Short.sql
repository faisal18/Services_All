USE ERX
Select top 1
(select count(*) from [transaction] with(nolock) where [Status] = 3) as 'ERX_Pending_Count',
(select COUNT(*) from [Transaction] with(nolock) where [Status] != 3
and convert(date,dateordered) = convert(date,getdate())) as 'ERX_Processed_Count',
(select COUNT(*) from [Transaction] with(nolock) where [Status] != 3
and convert(date,dateordered) = convert(date,getdate())
and [plan] in (select id from [plan] where payer not in (22))) as 'ERX_Payer_Processed_Count'
from [Transaction] with(nolock)