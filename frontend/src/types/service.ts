export type Service = {
  serviceId: string;
  contractorId: string;
  name: string;
  cityName: string;
  description: string;
  lowerPriceBound: string;
  upperPriceBound: string;
  averageRating: 0;
  reviewsCount: 0;
};

export type ServiceStats = {
  serviceId: string;
  serviceName: string;
  pendingRequestsCount: number;
  notFinishedOrdersCount: number;
};

export type ContactInfo = {
  type: "Phone" | "Telegram";
  value: string;
};

export type ServiceRequest = {
  requestId: string;
  description: string;
  paymentAmount: 12;
  requestDate: string;
  requestStatus: "Pending" | "";
  customerName: string;
  customerContactInfo: ContactInfo;
};

export type RequestStatus = "Pending" | "Declined";
export type OrderStatus = "NotStarted" | "Finished" | "InProgress";

export type ServiceOrder = {
  orderId: string;
  description: string;
  paymentAmount: number;
  requestDate: string;
  orderStatus: OrderStatus;
  customerName: string;
  customerContactInfo: ContactInfo;
};

export type CustomerServiceOrder = {
  requestId: string;
  description: string;
  paymentAmount: number;
  requestDate: string;
  orderStatus: OrderStatus;
  contractorName: string;
  serviceId: string;
  serviceName: string;
  contractorContactInfo: ContactInfo;
};

export type CustomerServiceRequest = {
  requestId: string;
  description: string;
  paymentAmount: number;
  requestDate: string;
  requestStatus: RequestStatus;
  contractorName: string;
  serviceId: string;
  serviceName: string;
  contractorContactInfo: ContactInfo;
};

export type ServiceReview = {
  reviewId: string;
  reviewerName: string;
  reviewText: string;
  reviewDate: string;
  rating: number;
};
