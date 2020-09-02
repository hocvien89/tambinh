--ALTER TABLE	dbo.Resources
--add ResourceId	int not null;

ALTER TABLE QT_DM_NHANVIEN
ADD ResourceID	int IDENTITY(1,1)

DELETE	dbo.Resources	;

INSERT INTO	 dbo.Resources
(
    --UniqueID - column value is auto-generated
	dbo.Resources.ResourceID,
    ResourceName,
    Color,
    Image,
    CustomField1
)
SELECT
qdn.ResourceId,qdn.nv_Hoten_vn, '','',qdn.uId_Nhanvien
from dbo.QT_DM_NHANVIEN qdn
