using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Nintek.Mathematics.Extensions;

namespace Nintek.Mathematics
{
    public class AssembleTokenizer : ISemanticTokenizer
    {
        readonly ITokenGrouper _tokenGrouper;
        readonly ITokenGroupAssembler _numberAssembler;
        readonly ITokenGroupAssembler _parenthesisAssembler;
        readonly ITokenGroupAssembler _operationAssembler;

        public AssembleTokenizer()
        {
            _tokenGrouper = new TokenGrouper();
            _numberAssembler = new NumberGroupAssembler();
            _parenthesisAssembler = new ParenthesisGroupAssembler(_numberAssembler);
            _operationAssembler = new OperationGroupAssembler();
        }

        public AssembleTokenizer(
            ITokenGrouper tokenGrouper,
            ITokenGroupAssembler numberAssembler,
            ITokenGroupAssembler parenthesisAssembler,
            ITokenGroupAssembler operationAssembler)
        {
            _tokenGrouper = tokenGrouper;
            _numberAssembler = numberAssembler;
            _parenthesisAssembler = parenthesisAssembler;
            _operationAssembler = operationAssembler;
        }

        public ITokenCollection Tokenize(ITokenCollection tokens)
        {
            var groups = _tokenGrouper.GroupTokens(tokens);
            var assembledGroups = groups.SelectMany(g => Assemble(g)).ToTokenCollection();
            return assembledGroups;
        }

        IEnumerable<IToken> Assemble(ITokenGroup group)
        {
            if (_numberAssembler.CanAssemble(group))
            {
                return _numberAssembler.Assemble(group.Tokens);
            }

            if (_parenthesisAssembler.CanAssemble(group))
            {
                return _parenthesisAssembler.Assemble(group.Tokens);
            }

            if (_operationAssembler.CanAssemble(group))
            {
                return _operationAssembler.Assemble(group.Tokens);
            }

            var exceptionMessage = $"Unknown rule for assembling token group.";
            throw new GroupAssemblingException(exceptionMessage, group);
        }
    }
}
