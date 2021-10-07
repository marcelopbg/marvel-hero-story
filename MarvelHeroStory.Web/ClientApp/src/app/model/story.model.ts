import { ICharacter } from "./character.model";

export interface IStory {
    attributionText: string
    description: string
    characters: ICharacter[]
}