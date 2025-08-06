import { SocialMedia } from './SocialMedia';
import { Event } from './Event';

export interface Speaker{
  Id: number;
  Name: string;
  ImageURL: string;
  Email: string;
  PhoneNumber: string;
  Resume: string;
  SocialMedias: SocialMedia[];
  SpeakerEvents: Event[];
}
