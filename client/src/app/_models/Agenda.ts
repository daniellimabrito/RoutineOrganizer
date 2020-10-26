import { Activity } from './Activity';
import { Priority } from './Priority';
import { Project } from './Project';
import { Proud } from './Proud';

export interface Agenda {
    id: string;
    name: string;
    notes: string;
    period: string;
    activities?: string; // Activity[];
    priorities: string; // Priority[];
    projects?: string; // Project[];
    prouds?: string; // Proud[];

}
