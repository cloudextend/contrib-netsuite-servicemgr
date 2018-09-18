import { SmartclientAppAuthNetsuitePage } from './app.po';

describe('smartclient-app-auth-netsuite App', () => {
  let page: SmartclientAppAuthNetsuitePage;

  beforeEach(() => {
    page = new SmartclientAppAuthNetsuitePage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
