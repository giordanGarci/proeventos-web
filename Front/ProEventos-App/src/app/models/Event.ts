import { Batch } from './Batch';
import { SocialMedia } from './SocialMedia';
import { Speaker } from './Speaker';

export interface Event{
  Id: number;
  Location: string;
  EventDate: Date;
  Theme: string;
  NumberOfPeople: number;
  ImageURL: string;
  Phone: string;
  Email: string;
  Batches: Batch[];
  SocialMedias: SocialMedia[];
  SpeakerEvents: Speaker[];
    }
