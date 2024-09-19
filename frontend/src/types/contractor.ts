export type ContractorContactType = "Phone" | "Telegram" | "WhatsApp" | "Viber";
export type Contractor = {
  id: string;
  name: string;
  additionalInfo: string;
  contactTypes: ContractorContactType[];
};
