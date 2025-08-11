
import {IWorkingHourInterval} from 'src/app/interface/IWorkingHourInterval'

export interface IBranchWorkingHours {
    id: number;
    intervals: IWorkingHourInterval[]; // ← الاسم لازم يطابق C# = "Intervals"
    branchId: number;
    startTime: Date;
    endTime: Date;
    isActive: boolean;
}



